using HtmlAgilityPack;
using System.Collections.Generic;
using System.Net;
using System.Web;
using StarWarsDestiny.Model;
using Xunit;
using System;
using Type = StarWarsDestiny.Model.Type;
using StarWarsDestiny.Common.Util;

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
                case "SetStarWars":
                    GetCardSet(td, card);
                    break;
                default:
                    throw new Exception("TD NOT FOUND");
            }
        }
        
    }
}
