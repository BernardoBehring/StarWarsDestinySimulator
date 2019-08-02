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

            var pagina = webClient.DownloadString("https://swdestinydb.com/find?q=a");
        }
    }
}
