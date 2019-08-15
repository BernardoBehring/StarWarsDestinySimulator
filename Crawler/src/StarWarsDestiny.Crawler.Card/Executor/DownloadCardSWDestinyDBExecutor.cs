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
            var lettersAndNumbers = LettersAndNumbers();

            foreach (var letterOrNumber in lettersAndNumbers)
            {
                var pageNumber = 1;
                var totalPages = 1;
                do
                {
                    var page = pageNumber == 1
                        ? webClient.DownloadString(
                            $"https://swdestinydb.com/find?q={letterOrNumber}&sort=name&view=list")
                        : webClient.DownloadString(
                            $"https://swdestinydb.com/find?q={letterOrNumber}&sort=name&view=list&page={pageNumber}");

                    await _extractor.ProcessPageAsync(page, null);

                    totalPages = _extractor.GetMaxPageNumber(page);
                    
                    pageNumber++;
                } while (pageNumber <= totalPages);

            }
        }

        private static List<char> LettersAndNumbers()
        {
            var letters = new List<char>
            {
                'a',
                'b',
                'c',
                'd',
                'e',
                'f',
                'g',
                'h',
                'i',
                'j',
                'k',
                'l',
                'm',
                'n',
                'o',
                'p',
                'q',
                'r',
                's',
                't',
                'u',
                'v',
                'w',
                'x',
                'y',
                'z',
                '0',
                '1',
                '2',
                '3',
                '4',
                '5',
                '6',
                '7',
                '8',
                '9'
            };
            return letters;
        }
    }
}
