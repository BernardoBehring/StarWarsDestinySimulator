using System.Collections.Generic;
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
            var sets = Sets();

            foreach (var set in sets)
            {
                //var pageNumber = 1;
                //var totalPages = 1;
                //do
                //{
                    var page = 
                        //    pageNumber == 1
                        //? 
                                webClient.DownloadString($"https://swdestinydb.com/set/{set}")
                        //: webClient.DownloadString(
                        //    $"https://swdestinydb.com/find?q={set}&sort=name&view=list&page={pageNumber}")
                    ;

                    await _extractor.ProcessPageAsync(page, null);

                //    totalPages = _extractor.GetMaxPageNumber(page);
                    
                //    pageNumber++;
                //} while (pageNumber <= totalPages);

            }
        }

        private static List<string> Sets()
        {
            var sets = new List<string>
            {
                "AW",
                "SoR",
                "EaW",
                "TPG",
                "LEG",
                "RIV",
                "WotF",
                "AtG",
                "CONV",
                "AoN",
                "SoH",
                "CM"
            };
            return sets;
        }
    }
}
