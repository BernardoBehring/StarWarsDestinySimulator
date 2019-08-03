using System.Net;
using System.Threading.Tasks;
using StarWarsDestiny.Crawler.Card.Interfaces;

namespace StarWarsDestiny.Crawler.Card.Executer
{
    public class DownloadCardSWDestinyDBExecutor : IDownloadCardSWDestinyDBExecutor
    {
        private readonly IDownloadCardSWDestinyDBExtractor _extractor;

        public WebClient webClient { get; set; }
        public DownloadCardSWDestinyDBExecutor(IDownloadCardSWDestinyDBExtractor extractor)
        {
            _extractor = extractor;
            webClient = new WebClient();
        }
        
        public async Task ExecuteAsync()
        {
            var page = webClient.DownloadString("https://swdestinydb.com/find?q=a&sort=name&view=list");

            await _extractor.ProcessPageAsync(page);
        }
    }
}
