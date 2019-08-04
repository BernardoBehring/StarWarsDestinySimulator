using HtmlAgilityPack;
using StarWarsDestiny.Common.Util;
using StarWarsDestiny.Crawler.Card.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarWarsDestiny.Model.Enum;
using CardSWD = StarWarsDestiny.Model.Card;

namespace StarWarsDestiny.Crawler.Card.Extractor
{
    public class DownloadCardSWDestinyDBExtractor : IDownloadCardSWDestinyDBExtractor
    {
        private readonly IRarityService _rarityService;
        private readonly ISetStarWarsService _setStarWarsService;
        private readonly IColorService _colorService;
        private readonly ITypeService _typeService;
        private readonly IFactionService _factionService;
        private readonly IAffiliationService _affiliationService;
        private readonly IDiceActionService _diceActionService;
        private readonly ICardService _cardService;

        public DownloadCardSWDestinyDBExtractor(IRarityService rarityService, ISetStarWarsService setStarWarsService,
            IColorService colorService, ITypeService typeService, IFactionService factionService, IAffiliationService affiliationService,
            IDiceActionService diceActionService, ICardService cardService)
        {
            _rarityService = rarityService;
            _setStarWarsService = setStarWarsService;
            _colorService = colorService;
            _typeService = typeService;
            _factionService = factionService;
            _affiliationService = affiliationService;
            _diceActionService = diceActionService;
            _cardService = cardService;
        }

        public int GetMaxPageNumber(string page)
        {
            if (page.Contains("Your query didn&#039;t match any card."))
                return 0;

            var document = new HtmlDocument();
            document.LoadHtml(page);

            var ul = document.DocumentNode.SelectSingleNode("//ul[@class='pagination']");

            var lis = ul.SelectNodes(".//li");

            var li = lis.LastOrDefault();

            if (li == default)
                return 1;

            var link = li.SelectSingleNode("./a");
            var href = link.Attributes["href"].Value;

            if (href == "#")
                return 1;

            var pageLink = "page=";
            var inic = href.IndexOf(pageLink) + pageLink.Length;
            var len = href.Length - inic;

            var pageNumber = href.Substring(inic, len);

            return Convert.ToInt32(pageNumber);
        }

        public async Task ProcessPageAsync(string page, object obj)
        {
            if (page.Contains("Your query didn&#039;t match any card."))
                return;

            var document = new HtmlDocument();
            document.LoadHtml(page);

            var table = document.DocumentNode.SelectSingleNode("//table[contains(@class, 'rwd-table')]");

            if (table != null)
            {
                var trs = table.SelectNodes("./tr");
                var listCards = new List<CardSWD>();

                foreach (var tr in trs)
                {
                    var tds = tr.SelectNodes("./td");
                    var card = new CardSWD
                    {
                        InsertedIn = DateTime.Now
                    };

                    foreach (var td in tds)
                    {
                        card = await GetCardAttributesAsync(td, card);
                    }

                    var cardInDB = await _cardService.GetCardInDb(card);

                    if (!cardInDB)
                    {
                        await _cardService.AddAsync(card);
                        Console.Write($"Card: {card.Name} included!");
                        listCards.Add(card);
                    }
                    else
                    {
                        Console.Write($"Card: {card.Name} alread exists!");
                    }

                }
            }
        }

        private async Task<CardSWD> GetCardAttributesAsync(HtmlNode td, CardSWD card)
        {
            var type = td.Attributes["data-th"].Value;
            var innerText = td.InnerText.FormatText();
            switch (type)
            {
                case "Name":
                    card = await GetCardNameAndColorAsync(card, td);
                    break;
                case "Affiliation":
                    card = await GetAffiliationAsync(card, innerText);
                    break;
                case "Faction":
                    card = await GetFactionAsync(card, innerText);
                    break;
                case "Points/Cost":
                    card = GetPointsCost(card, innerText);
                    break;
                case "Health":
                    card = GetHealth(card, innerText);
                    break;
                case "Type":
                    card = await GetCardTypeAsync(card, innerText);
                    break;
                case "Rarity":
                    card = await GetRarityIdAsync(card, innerText);
                    break;
                case "Die":
                    card = await GetDieFaceAsync(card, td, innerText);
                    break;
                case "Set":
                    card = await GetCardSetAsync(card, td);
                    break;
                default:
                    throw new Exception("TD NOT FOUND");
            }

            return card;
        }

        private async Task<CardSWD> GetRarityIdAsync(CardSWD card, string innerText)
        {
            card.RarityId = await _rarityService.GetModelIdAsync(innerText);
            return card;
        }

        private async Task<CardSWD> GetCardSetAsync(CardSWD card, HtmlNode td)
        {
            var span = td.SelectSingleNode("./span[@class='hidden-xs']");
            
            var setName = span.InnerText.FormatText();
            card.SetStarWarsId = await _setStarWarsService.GetModelIdAsync(setName);
            card.Number = Convert.ToInt32(td.InnerText.FormatText().Replace(setName, ""));

            return card;
        }

        private async Task<CardSWD> GetCardNameAndColorAsync(CardSWD card, HtmlNode td)
        {
            var span = td.SelectSingleNode("./span");
            var classSpan = span.Attributes["class"].Value;
            var link = td.SelectSingleNode("./a");
            var subtitle = link.SelectSingleNode("./span[@class='card-subtitle']");
            var name = link.InnerText.FormatText();

            if (subtitle != default)
            {
                card.Subtitle = subtitle.InnerText.FormatText().Substring(2);
                name = name.Replace(subtitle.InnerText.FormatText(), "");
            }

            card.Name = name;
            card.Url = link.Attributes["href"].Value;
            card.DataCode = link.Attributes["data-code"].Value;

            if (classSpan.Contains("character"))
                card.IsCharacter = true;
            else
                card.IsCharacter = false;

            return await GetColorAsync(card, classSpan);
        }

        private async Task<CardSWD> GetColorAsync(CardSWD card, string classSpan)
        {
            var color = string.Empty;

            if (classSpan.Contains("yellow"))
            {
                color = "Yellow";
            }
            else if (classSpan.Contains("red"))
            {
                color = "Red";
            }
            else if (classSpan.Contains("blue"))
            {
                color = "Blue";
            }
            else if (classSpan.Contains("gray"))
            {
                color = "Gray";
            }

            card.ColorId = await _colorService.GetModelIdAsync(color);
            return card;
        }

        private async Task<CardSWD> GetCardTypeAsync(CardSWD card, string innerText)
        {
            var typeId = await _typeService.GetModelIdAsync(innerText);

            if (card.CardTypes == null)
            {
                card.CardTypes = new List<CardType>();
            }

            var cardType = new CardType
            {
                Card = card,
                InsertedIn = DateTime.Now,
                TypeId = typeId
            };

            card.CardTypes.Add(cardType);
            return card;
        }

        private CardSWD GetHealth(CardSWD card, string innerText)
        {
            var health = innerText;
            if (!string.IsNullOrWhiteSpace(health))
            {
                card.Health = Convert.ToInt32(health);
            }
            return card;
        }

        private async Task<CardSWD> GetFactionAsync(CardSWD card, string innerText)
        {
            card.FactionId = await _factionService.GetModelIdAsync(innerText);
            return card;
        }

        private CardSWD GetPointsCost(CardSWD card, string innerText)
        {
            var pointsCost = innerText;
            var pointsSplit = pointsCost.Split('/');
            if (card.IsCharacter)
            {
                if (pointsSplit.Length > 1)
                    card.ElitePoints = Convert.ToInt32(pointsSplit[1]);
                card.Points = Convert.ToInt32(pointsSplit[0]);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(pointsCost))
                    card.Cost = Convert.ToInt32(pointsCost);
            }

            return card;
        }

        private async Task<CardSWD> GetAffiliationAsync(CardSWD card, string innerText)
        {
            card.AffiliationId = await _affiliationService.GetModelIdAsync(innerText);
            return card;
        }

        private async Task<CardSWD> GetDieFaceAsync(CardSWD card, HtmlNode td, string innerText)
        {
            var spanDie = td.SelectSingleNode("./span");
            if (spanDie != null)
            {
                var cardInDB = await _cardService.GetCardInDb(card);
                if (!cardInDB)
                {
                    if (card.Die == null)
                    {
                        card.Die = new Die
                        {
                            InsertedIn = DateTime.Now,
                            Card = card
                        };
                    }

                    var classDie = spanDie.Attributes["class"].Value;
                    var diceActionId = await GetDiceActionAsync(classDie);

                    if (card.Die.DiceFaces == null)
                    {
                        card.Die.DiceFaces = new List<DiceFace>();
                    }

                    var isModifier = false;

                    if (innerText.Contains("+"))
                    {
                        isModifier = true;
                        innerText = innerText.Replace("+", "");
                    }

                    var splitValueCost = innerText.Split('/');

                    var dieFace = new DiceFace
                    {
                        Value = string.IsNullOrWhiteSpace(splitValueCost[0]) ? "0" : splitValueCost[0].Trim(),
                        Cost = splitValueCost.Length == 1 || string.IsNullOrWhiteSpace(splitValueCost[1])
                            ? 0
                            : Convert.ToInt32(splitValueCost[1]),
                        DiceActionId = diceActionId,
                        IsModifier = isModifier,
                        InsertedIn = DateTime.Now,
                        Die = card.Die
                    };

                    card.Die.DiceFaces.Add(dieFace);
                }
            }

            return card;
        }

        private async Task<int> GetDiceActionAsync(string classDie)
        {
            EnumDiceAction diceAction;

            if (classDie.Contains("melee"))
            {
                diceAction = EnumDiceAction.Melee;
            }
            else if (classDie.Contains("ranged"))
            {
                diceAction = EnumDiceAction.Ranged;
            }
            else if (classDie.Contains("shield"))
            {
                diceAction = EnumDiceAction.Shield;
            }
            else if (classDie.Contains("resource"))
            {
                diceAction = EnumDiceAction.Resource;
            }
            else if (classDie.Contains("special"))
            {
                diceAction = EnumDiceAction.Special;
            }
            else if (classDie.Contains("blank"))
            {
                diceAction = EnumDiceAction.Blank;
            }
            else if (classDie.Contains("disrupt"))
            {
                diceAction = EnumDiceAction.Disrupt;
            }
            else if (classDie.Contains("discard"))
            {
                diceAction = EnumDiceAction.Discard;
            }
            else if (classDie.Contains("focus"))
            {
                diceAction = EnumDiceAction.Focus;
            }
            else if (classDie.Contains("indirect"))
            {
                diceAction = EnumDiceAction.Indirect;
            }
            else
            {
                throw new Exception("DICE ACTION NOT IN DATABASE");
            }

            return await _diceActionService.GetModelIdAsync(Enum.GetName(typeof(EnumDiceAction), diceAction));
        }
    }
}
