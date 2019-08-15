using System.Net;
using System.Threading.Tasks;
using StarWarsDestiny.Crawler.Deck.Interfaces;

namespace StarWarsDestiny.Crawler.Deck.Executor
{
    public class DownloadDeckDetailsSWDestinyDBExecutor : IDownloadDeckDetailsSWDestinyDBExecutor
    {
        private readonly IDownloadDeckDetailsSWDestinyDBExtractor _extractor;
        public WebClient webClient { get; set; }

        public DownloadDeckDetailsSWDestinyDBExecutor(IDownloadDeckDetailsSWDestinyDBExtractor extractor)
        {
            _extractor = extractor;
            webClient = new WebClient();
        }

        public Task ExecuteAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
