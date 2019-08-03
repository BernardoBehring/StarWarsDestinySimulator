using System.Net;
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
        }
    }
}
