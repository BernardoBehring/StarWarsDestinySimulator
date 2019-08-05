using System.Threading.Tasks;
using HtmlAgilityPack;
using StarWarsDestiny.Common.Util;
using StarWarsDestiny.Crawler.Card.Interfaces;
using StarWarsDestiny.Service.Interfaces;
using CardSWD = StarWarsDestiny.Model.Card;

namespace StarWarsDestiny.Crawler.Card.Extractor
{
    public class DownloadCardDetailSWDestinyDBExtractor : IDownloadCardDetailSWDestinyDBExtractor
    {
        private readonly ICardService _cardService;
        private readonly IArtistService _artistService;
        private readonly ILegalityService _legalityService;

        public DownloadCardDetailSWDestinyDBExtractor(ICardService cardService,
            IArtistService artistService, ILegalityService legalityService)
        {
            _cardService = cardService;
            _artistService = artistService;
            _legalityService = legalityService;
        }

        public async Task ProcessPageAsync(string page, object obj)
        {
            var card = (CardSWD) obj;
            var document = new HtmlDocument();
            document.LoadHtml(page);

            var divs = document.DocumentNode.SelectNodes("//div[@id='list']/div[@class='row'");

            if (divs != null)
            {
                var divDetails = divs[1].SelectNodes("./div/div[@class='row']/div");

                foreach (var details in divDetails)
                {
                    var panelDefault = details.SelectSingleNode("./div/div/div/div[contains(@class, 'panel-default')]");
                    var panelHead = panelDefault.SelectSingleNode("./div[contains(@class, 'panel-heading')]");
                    
                    var title = panelHead.SelectSingleNode("./h3");
                    var spanUnique = title.SelectSingleNode("./span[class='icon-unique'");

                    var panelContent = panelDefault.SelectSingleNode("./div[contains(@class, 'panel-body')]");
                    var cardText = panelContent.SelectSingleNode("./div[contains(@class, 'card-text')]");
                    var cardFlavor = panelContent.SelectSingleNode("./div[contains(@class, 'card-flavor')]");
                    var cardIllustrator = panelContent.SelectSingleNode("./div[contains(@class, 'card-illustrator')]");

                    var cardLegality = panelContent.SelectSingleNode("./div[contains(@class, 'card-legality')]");
                    var cardBalance = panelContent.SelectSingleNode("./div[contains(@class, 'card-balance')]");

                    card.ArtistId = await _artistService.GetModelIdAsync(cardIllustrator.InnerText.FormatText());

                    card.IsUnique = spanUnique != null;
                    card.Text = GetCardText(cardText);
                    card.Flavor = cardFlavor.InnerText.FormatText();
                }

                await _cardService.PartialUpdateAsync(card,
                    new[] {nameof(CardSWD.IsUnique), nameof(CardSWD.Text), nameof(CardSWD.Flavor)});
            }
        }

        public async Task InsertCardLegality(HtmlNode divLegality, CardSWD card)
        {
            var table = divLegality.SelectSingleNode("./div/table");

            var ths = table.SelectNodes("./thead/tr/th");

            foreach (var th in ths)
            {
                var legalityId = _legalityService.GetModelIdAsync(th.InnerText.FormatText());
            }
        }

        public string GetCardText(HtmlNode divCardText)
        {
            return null;
        }
    }
}
