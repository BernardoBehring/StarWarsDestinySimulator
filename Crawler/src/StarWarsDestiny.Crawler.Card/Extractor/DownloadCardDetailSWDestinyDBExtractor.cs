using System;
using System.Threading.Tasks;
using HtmlAgilityPack;
using StarWarsDestiny.Common.Util;
using StarWarsDestiny.Crawler.Card.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Service.Interfaces;
using CardSWD = StarWarsDestiny.Model.Card;

namespace StarWarsDestiny.Crawler.Card.Extractor
{
    public class DownloadCardDetailSWDestinyDBExtractor : IDownloadCardDetailSWDestinyDBExtractor
    {
        private readonly ICardService _cardService;
        private readonly IArtistService _artistService;
        private readonly ILegalityService _legalityService;
        private readonly ICardLegalityService _cardLegalityService;
        private readonly IBalanceForceService _balanceForceService;

        public DownloadCardDetailSWDestinyDBExtractor(ICardService cardService,
            IArtistService artistService, ILegalityService legalityService, 
            ICardLegalityService cardLegalityService, IBalanceForceService balanceForceService)
        {
            _cardService = cardService;
            _artistService = artistService;
            _legalityService = legalityService;
            _cardLegalityService = cardLegalityService;
            _balanceForceService = balanceForceService;
        }

        public async Task ProcessPageAsync(string page, object obj)
        {
            var card = (CardSWD) obj;
            var document = new HtmlDocument();
            document.LoadHtml(page);

            var divs = document.DocumentNode.SelectNodes("//div[@id='list']/div[@class='row']");

            if (divs != null)
            {
                var divDetails = divs[1].SelectNodes("./div/div[@class='row']/div");

                foreach (var details in divDetails)
                {
                    if (details.Attributes["data-code"] != default)
                    {
                        await GetCardDetails(details, card);
                    }
                    else if (card.UrlImage == default)
                    {
                        if (details.InnerText.Contains("No image") ||
                            details.SelectSingleNode("./div[@id='reviews-header']") != null ||
                            details.InnerText.Contains("Reviews will be enabled for this card when it is officially released."))
                            continue;
                        var img = details.SelectSingleNode("./div/img");
                        var urlImg = img.Attributes["src"].Value;
                        card.UrlImage = urlImg;
                    }
                }

                await _cardService.PartialUpdateAsync(card,
                    new[]
                    {
                        nameof(CardSWD.IsUnique),
                        nameof(CardSWD.Text),
                        nameof(CardSWD.Flavor),
                        nameof(CardSWD.UrlImage)
                    });
                Console.WriteLine($"Card [{card.Name}] details saved!");
            }
        }

        private async Task GetCardDetails(HtmlNode details, CardSWD card)
        {
            var panelDefault = details.SelectSingleNode("./div/div[contains(@class, 'panel-default')]");
            var panelHead = panelDefault.SelectSingleNode("./div[contains(@class, 'panel-heading')]");

            var title = panelHead.SelectSingleNode("./h3");
            var spanUnique = title.SelectSingleNode("./span[class='icon-unique']");

            var panelContent = panelDefault.SelectSingleNode("./div[contains(@class, 'panel-body')]");
            var cardText = panelContent.SelectSingleNode("./div[contains(@class, 'card-text')]");
            var cardFlavor = panelContent.SelectSingleNode("./div[contains(@class, 'card-flavor')]");
            var cardIllustrator = panelContent.SelectSingleNode("./div[contains(@class, 'card-illustrator')]");

            var cardLegality = panelContent.SelectSingleNode("./div[contains(@class, 'card-legality-table')]");
            var cardBalance = panelContent.SelectSingleNode("./div[contains(@class, 'card-balance-table')]");

            if(cardIllustrator != null)
                card.ArtistId = await _artistService.GetModelIdAsync(cardIllustrator.InnerText.FormatText());
            if (cardLegality != null)
                await InsertCardLegality(cardLegality, card);
            if (cardBalance != null)
                await InsertCardBalance(cardBalance, card);

            card.IsUnique = spanUnique != null;
            card.Text = GetCardText(cardText);
            card.Flavor = cardFlavor.InnerText.FormatText();
        }
        private async Task InsertCardBalance(HtmlNode divBalance, CardSWD card)
        {
            var table = divBalance.SelectSingleNode("./div/table");
            var ths = table.SelectNodes("./thead/tr/th");
            var tds = table.SelectNodes("./tr/td");

            for (int i = 0; i < ths.Count; i++)
            {
                var th = ths[i];
                var td = tds[i];
                var legalityId = await _legalityService.GetModelIdAsync(th.InnerText.FormatText());
                var cardLegality = await _cardLegalityService.GetCardLegalityByCardLegality(card.Id, legalityId);

                var balanceForceInDb = await _balanceForceService.GetBalanceForceByCardLegality(cardLegality.Id);
                var innerText = td.InnerText.FormatText();
                var splitInnerText = innerText.Split('/');
                var points = Convert.ToInt32(splitInnerText[0]);
                var elitePoints = splitInnerText.Length > 1 ? Convert.ToInt32(splitInnerText[1]) : (int?)null;

                if (balanceForceInDb == default)
                {
                    var balanceForce = new BalanceForce
                    {
                        CardLegalityId = cardLegality.Id,
                        ElitePoints = elitePoints,
                        InsertedIn = DateTime.Now,
                        Points = points
                    };

                    await _balanceForceService.CreateAsync(balanceForce);
                }
                else
                {
                    balanceForceInDb.ElitePoints = elitePoints;
                    balanceForceInDb.Points = points;

                    await _balanceForceService.PartialUpdateAsync(balanceForceInDb,
                        new[] {nameof(BalanceForce.ElitePoints), nameof(BalanceForce.Points)});
                }
            }
        }
        private async Task InsertCardLegality(HtmlNode divLegality, CardSWD card)
        {
            var table = divLegality.SelectSingleNode("./div/table");

            var ths = table.SelectNodes("./thead/tr/th");
            var tds = table.SelectNodes("./tr/td");

            for (int i = 0; i < ths.Count; i++)
            {
                var th = ths[i];
                var td = tds[i];
                var legalityId = await _legalityService.GetModelIdAsync(th.InnerText.FormatText());
                var isLegal = !td.Attributes["class"].Value.Contains("no-legal");

                var cardLegalityInDB = await _cardLegalityService.GetCardLegalityByCardLegality(card.Id, legalityId);

                if (cardLegalityInDB == default)
                {
                    var cardLegality = new CardLegality
                    {
                        CardId = card.Id,
                        InsertedIn = DateTime.Now,
                        IsLegal = isLegal,
                        LegalityId = legalityId
                    };
                    await _cardLegalityService.CreateAsync(cardLegality);
                }
                else
                {
                    cardLegalityInDB.IsLegal = isLegal;
                    await _cardLegalityService.PartialUpdateAsync(cardLegalityInDB,
                        new[] {nameof(CardLegality.IsLegal)});
                }
            }
        }

        public string GetCardText(HtmlNode divCardText)
        {
            var replaceIni = "<span class=\"";
            var replaceEnd = "\"></span>";
            var text = divCardText.OuterHtml.Replace(replaceIni, "").Replace(replaceEnd, "");
            var document = new HtmlDocument();
            document.LoadHtml(text);

            return document.DocumentNode.InnerText.FormatText();
        }
    }
}
