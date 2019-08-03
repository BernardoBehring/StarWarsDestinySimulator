using HtmlAgilityPack;
using StarWarsDestiny.Common.Util;
using StarWarsDestiny.Crawler.Card.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StarWarsDestiny.Model.Enum;
using CardSWD = StarWarsDestiny.Model.Card;
using Type = StarWarsDestiny.Model.Type;

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

        public DownloadCardSWDestinyDBExtractor(IRarityService rarityService, ISetStarWarsService setStarWarsService,
            IColorService colorService, ITypeService typeService, IFactionService factionService, IAffiliationService affiliationService,
            IDiceActionService diceActionService)
        {
            _rarityService = rarityService;
            _setStarWarsService = setStarWarsService;
            _colorService = colorService;
            _typeService = typeService;
            _factionService = factionService;
            _affiliationService = affiliationService;
            _diceActionService = diceActionService;
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

        private async Task<CardSWD> GetCardNameAndColorAsync(HtmlNode td, CardSWD card)
        {
            var span = td.SelectSingleNode("./span");
            var classSpan = span.Attributes["class"].Value;

            if (classSpan.Contains("character"))
                card = new CharacterCard();
            else
                card = new NonCharacterCard();

            var link = td.SelectSingleNode("./a");
            card.Name = link.InnerText.FormatText();
            card.Url = link.Attributes["href"].Value;
            card.DataCode = link.Attributes["data-code"].Value;

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
                var characterCard = (CharacterCard)card;
                if (characterCard.CharacterAtributes == null)
                    characterCard.CharacterAtributes = new CharacterAtributes();
                characterCard.CharacterAtributes.Health = Convert.ToInt32(health);
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
            if (card is CharacterCard)
            {
                var characterCard = (CharacterCard)card;
                if (characterCard.CharacterAtributes == null)
                    characterCard.CharacterAtributes = new CharacterAtributes();
                if (pointsSplit.Length > 1)
                    characterCard.CharacterAtributes.ElitePoints = Convert.ToInt32(pointsSplit[1]);
                characterCard.CharacterAtributes.Points = Convert.ToInt32(pointsSplit[0]);
            }
            else if (card is NonCharacterCard)
            {
                var nonCharacterCard = (NonCharacterCard)card;
                if (!string.IsNullOrWhiteSpace(pointsCost))
                    nonCharacterCard.Cost = Convert.ToInt32(pointsCost);
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
                if (card.Die == null)
                {
                    card.Die = new Die();
                }

                var classDie = spanDie.Attributes["class"].Value;
                var diceActionId = await GetDiceActionAsync(classDie);

                if (card.Die.Faces == null)
                {
                    card.Die.Faces = new List<DiceFace>();
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
                    Value = string.IsNullOrWhiteSpace(splitValueCost[0]) ? 0 : Convert.ToInt32(splitValueCost[0]),
                    Cost = splitValueCost.Length == 1 || string.IsNullOrWhiteSpace(splitValueCost[1])
                        ? 0
                        : Convert.ToInt32(splitValueCost[1]),
                    DiceActionId = diceActionId,
                    IsModifier = isModifier
                };

                card.Die.Faces.Add(dieFace);
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
