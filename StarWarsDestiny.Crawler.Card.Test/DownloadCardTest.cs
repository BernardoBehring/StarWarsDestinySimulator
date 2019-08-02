using HtmlAgilityPack;
using System.Collections.Generic;
using System.Net;
using System.Web;
using Xunit;

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
                var card = new Model.Card();

                foreach (var td in tds)
                {
                    var type = td.Attributes["data-th"].Value;

                    switch (type)
                    {
                        case "Name":
                            var link = td.SelectSingleNode("./a");
                            card.Name = HttpUtility.HtmlEncode(link.InnerText);
                            break;
                        case "Affiliation":
                            card.Affiliation.Name = HttpUtility.HtmlEncode(td.InnerText);
                            break;
                        case "Faction":
                            break;
                        case "Points/Cost":
                            break;
                        case "Health":
                            break;
                        case "Type":
                            break;
                        case "Rarity":
                            break;
                        case "Die":
                            break;
                        case "Set":
                            break;
                        default:
                            break;;
                    }
                    listCards.Add(card);
                }
            }
        }
    }
}
