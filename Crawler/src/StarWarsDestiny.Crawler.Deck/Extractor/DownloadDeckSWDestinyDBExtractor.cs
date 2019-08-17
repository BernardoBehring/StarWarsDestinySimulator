using HtmlAgilityPack;
using System.Threading.Tasks;
using StarWarsDestiny.Crawler.Deck.Interfaces;
using System;
using StarWarsDestiny.Common.Util.Extensions;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.Crawler.Deck.Extractor
{
    public class DownloadDeckSWDestinyDBExtractor : IDownloadDeckSWDestinyDBExtractor
    {
        private readonly IDeckService _deckService;

        public DownloadDeckSWDestinyDBExtractor(IDeckService deckService)
        {
            _deckService = deckService;
        }

        public int GetMaxPageNumber(string page)
        {
            var document = new HtmlDocument();
            document.LoadHtml(page);

            var ul = document.DocumentNode.SelectSingleNode("//ul[@class='pagination pagination-sm']");

            var lis = ul.SelectNodes(".//li");

            var li = lis[lis.Count - 1];

            if (li == default)
                return 1;

            var link = li.SelectSingleNode("./a");
            var href = link.Attributes["href"].Value;

            if (href == "#")
                return 1;

            var pageLink = "popular/";
            var inic = href.IndexOf(pageLink) + pageLink.Length;
            var len = href.Length - inic;

            var pageNumber = href.Substring(inic, len);

            return Convert.ToInt32(pageNumber);
        }

        public async Task ProcessPageAsync(string page, object obj)
        {
            var document = new HtmlDocument();
            document.LoadHtml(page);

            var listA = document.DocumentNode.SelectNodes("//a[@class='decklist-name']");

            foreach (var deck in listA)
            {
                var name = deck.InnerText.FormatText();
                var url = deck.Attributes["href"].Value;
                
                var deckModel = new StarWarsDestiny.Model.Deck
                {
                    InsertedIn = DateTime.Now,
                    Name = name,
                    Url = url
                };

                var deckOnDb = await _deckService.GetByNameAndUrl(name, url);

                if(deckOnDb == default)
                    await _deckService.CreateAsync(deckModel);
            }
        }
    }
}
