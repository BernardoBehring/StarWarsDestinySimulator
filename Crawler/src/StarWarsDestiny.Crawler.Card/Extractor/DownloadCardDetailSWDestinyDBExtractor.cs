using System.Threading.Tasks;
using HtmlAgilityPack;
using StarWarsDestiny.Crawler.Card.Interfaces;
using StarWarsDestiny.Service.Interfaces;
using CardSWD = StarWarsDestiny.Model.Card;

namespace StarWarsDestiny.Crawler.Card.Extractor
{
    public class DownloadCardDetailSWDestinyDBExtractor : IDownloadCardDetailSWDestinyDBExtractor
    {
        private readonly ICardService _cardService;

        public DownloadCardDetailSWDestinyDBExtractor(ICardService cardService)
        {
            _cardService = cardService;
        }

        public async Task ProcessPageAsync(string page, object obj)
        {
            var card = (CardSWD) obj;
            var document = new HtmlDocument();
            document.LoadHtml(page);

            await _cardService.PartialUpdateAsync(card, new[] {""});
        }
    }
}
