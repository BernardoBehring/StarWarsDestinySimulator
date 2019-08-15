using System.Net;
using System.Threading.Tasks;
using StarWarsDestiny.Crawler.Deck.Interfaces;

namespace StarWarsDestiny.Crawler.Deck.Executor
{
    public class DownloadDeckSWDestinyDBExecutor : IDownloadDeckSWDestinyDBExecutor
    {
        private readonly IDownloadDeckSWDestinyDBExtractor _extractor;
        public WebClient webClient { get; set; }

        public DownloadDeckSWDestinyDBExecutor(IDownloadDeckSWDestinyDBExtractor extractor)
        {
            _extractor = extractor;
            webClient = new WebClient();
        }

        public async Task ExecuteAsync()
        {
            var pageNumber = 1;
            var totalPages = 1;

            do
            {
                var page = pageNumber == 1
                    ? webClient.DownloadString(
                        $"https://swdestinydb.com/decklists")
                    : webClient.DownloadString(
                        $"https://swdestinydb.com/decklists/popular/{pageNumber}");

                await _extractor.ProcessPageAsync(page, null);

                totalPages = _extractor.GetMaxPageNumber(page);

                pageNumber++;
            } while (pageNumber <= totalPages);
        }
    }
}
