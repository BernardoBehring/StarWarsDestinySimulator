using HtmlAgilityPack;
using System.Collections.Generic;
using System.Net;
using System.Web;
using StarWarsDestiny.Model;
using Xunit;
using System;
using Type = StarWarsDestiny.Model.Type;

namespace StarWarsDestiny.Crawler.Card.Test
{
    public class DownloadCardTest
    {
        [Fact]
        public void PageTest()
        {
            var webClient = new WebClient();

            var page = webClient.DownloadString("https://swdestinydb.com/find?q=a&sort=name&view=list");

            var document = new HtmlDocument();
            document.LoadHtml(page);

            var table = document.DocumentNode.SelectSingleNode("//table[contains(@class, 'rwd-table')]");

            var trs = table.SelectNodes("./tr");
            var listCards = new List<Model.Card>();

            foreach (var tr in trs)
            {
                var tds = tr.SelectNodes("./td");
                Model.Card card = null;
                Die die = null;

                foreach (var td in tds)
                {
                    GetCardAttributes(td, ref card, ref die);
                }

                listCards.Add(card);
            }
        }

        private void GetCardAttributes(HtmlNode td, ref Model.Card card, ref Die die)
        {
            var type = td.Attributes["data-th"].Value;
            var innerText = td.InnerText.FormatText();
            switch (type)
            {
                case "Name":
                    GetCardNameAndColor(td, ref card);
                    break;
                case "Affiliation":
                    GetAffiliation(card, innerText);
                    break;
                case "Faction":
                    GetFaction(card, innerText);
                    break;
                case "Points/Cost":
                    GetPointsCost(card, innerText);
                    break;
                case "Health":
                    GetHealth(card, innerText);
                    break;
                case "Type":
                    GetCardType(card, innerText);
                    break;
                case "Rarity":
                    GetRarity(card, innerText);
                    break;
                case "Die":
                    GetDieFace(card, td, ref die, innerText);
                    break;
                case "Set":
                    GetCardSet(td, card);
                    break;
                default:
                    throw new Exception("TD NOT FOUND");
            }
        }

        private static void GetRarity(Model.Card card, string innerText)
        {
            if(card.Rarity == null)
                card.Rarity = new Rarity();
            card.Rarity.Name = innerText;
        }

        private static void GetCardSet(HtmlNode td, Model.Card card)
        {
            var span = td.SelectSingleNode("./span[@class='hidden-xs']");

            if (card.Set == null)
                card.Set = new Set();

            var setName = span.InnerText.FormatText();
            card.Set.Name = setName;
            card.Number = Convert.ToInt32(td.InnerText.FormatText().Replace(setName, ""));
        }

        private static void GetCardNameAndColor(HtmlNode td, ref Model.Card card)
        {
            var span = td.SelectSingleNode("./span");
            var classSpan = span.Attributes["class"].Value;

            if(classSpan.Contains("character"))
                card = new CharacterCard();
            else
                card = new NonCharacterCard();

            var link = td.SelectSingleNode("./a");
            card.Name = link.InnerText.FormatText();
            card.Url = link.Attributes["href"].Value;
            card.DataCode = link.Attributes["data-code"].Value;

            if (card.Color == null)
                card.Color = new Color();

            if (classSpan.Contains("yellow"))
            {
                card.Color.Name = "Yellow";
            }
            else if (classSpan.Contains("red"))
            {
                card.Color.Name = "Red";
            }
            else if (classSpan.Contains("blue"))
            {
                card.Color.Name = "Blue";
            }
            else if (classSpan.Contains("gray"))
            {
                card.Color.Name = "Gray";
            }
        }

        private static void GetCardType(Model.Card card, string innerText)
        {
            if (card.Types == null)
            {
                card.Types = new List<Type>();
            }

            var cardType = new Type
            {
                Name = innerText
            };
            card.Types.Add(cardType);
        }

        private static void GetHealth(Model.Card card, string innerText)
        {
            var health = innerText;
            if (!string.IsNullOrWhiteSpace(health))
            {
                var characterCard = (CharacterCard) card;
                if (characterCard.CharacterAtributes == null)
                    characterCard.CharacterAtributes = new CharacterAtributes();
                characterCard.CharacterAtributes.Health = Convert.ToInt32(health);
            }
        }

        private static void GetFaction(Model.Card card, string innerText)
        {
            if(card.Faction == null)
                card.Faction = new Faction();
            card.Faction.Name = innerText;
        }

        private static void GetPointsCost(Model.Card card, string innerText)
        {
            var pointsCost = innerText;
            var pointsSplit = pointsCost.Split('/');
            if (card is CharacterCard)
            {
                var characterCard = (CharacterCard)card;
                if (characterCard.CharacterAtributes == null)
                    characterCard.CharacterAtributes = new CharacterAtributes();
                if(pointsSplit.Length > 1)
                    characterCard.CharacterAtributes.ElitePoints = Convert.ToInt32(pointsSplit[1]);
                characterCard.CharacterAtributes.Points = Convert.ToInt32(pointsSplit[0]);
            }
            else if(card is NonCharacterCard)
            {
                var nonCharacterCard = (NonCharacterCard) card;
                if (!string.IsNullOrWhiteSpace(pointsCost))
                    nonCharacterCard.Cost = Convert.ToInt32(pointsCost);
            }
        }

        private static void GetAffiliation(Model.Card card, string innerText)
        {
            if(card.Affiliation == null)
                card.Affiliation = new Affiliation();
            card.Affiliation.Name = innerText;
        }

        private void GetDieFace(Model.Card card, HtmlNode td, ref Die die, string innerText)
        {
            var spanDie = td.SelectSingleNode("./span");
            if (spanDie != null)
            {
                if (die == null)
                {
                    die = new Die();
                    card.Die = die;
                }

                var classDie = spanDie.Attributes["class"].Value;
                var diceAction = GetDiceAction(classDie);

                if (die.Faces == null)
                {
                    die.Faces = new List<DiceFace>();
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
                    DiceAction = diceAction,
                    IsModifier = isModifier
                };

                die.Faces.Add(dieFace);
            }
        }

        private DiceAction GetDiceAction(string classDie)
        {
            var diceAction = new DiceAction();

            if (classDie.Contains("melee"))
            {
                diceAction.Name = "Melee";
            }
            else if (classDie.Contains("ranged"))
            {
                diceAction.Name = "Ranged";
            }
            else if (classDie.Contains("shield"))
            {
                diceAction.Name = "Shield";
            }
            else if (classDie.Contains("resource"))
            {
                diceAction.Name = "Resource";
            }
            else if (classDie.Contains("special"))
            {
                diceAction.Name = "Special";
            }
            else if (classDie.Contains("blank"))
            {
                diceAction.Name = "Blank";
            }
            else if (classDie.Contains("disrupt"))
            {
                diceAction.Name = "Disrupt";
            }
            else if (classDie.Contains("discard"))
            {
                diceAction.Name = "Discard";
            }
            else if (classDie.Contains("focus"))
            {
                diceAction.Name = "Focus";
            }
            else if (classDie.Contains("indirect"))
            {
                diceAction.Name = "Indirect";
            }
            else
            {
                throw new Exception("DICE ACTION NOT IN DATABASE");
            }

            return diceAction;
        }
    }

    public static class StringExtensions
    {
        public static string FormatText(this string value)
        {
            return HttpUtility.HtmlDecode(value).Replace("\n", "").Replace("\t", "").Trim();
        }
    }
}
