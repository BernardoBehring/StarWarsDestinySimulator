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
        }
        
        public Task Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
