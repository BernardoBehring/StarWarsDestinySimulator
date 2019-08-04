using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using StarWarsDestiny.Crawler.Card.Interfaces;
using StarWarsDestiny.Service.Interfaces;


namespace StarWarsDestiny.Crawler.Card.Executer
{
    public class DownloadCardDetailSEDestinyDBExecutor : IDownloadCardSWDestinyDBExecutor
    {
        private readonly IDownloadCardDetailSWDestinyDBExtractor _extractor;
        private readonly ICardService _cardService;

        public WebClient webClient { get; set; }
        public DownloadCardDetailSEDestinyDBExecutor(IDownloadCardDetailSWDestinyDBExtractor extractor,
            ICardService cardService)
        {
            _extractor = extractor;
            _cardService = cardService;
            webClient = new WebClient();
        }

        public async Task ExecuteAsync()
        {
            var cards = await _cardService.GetAllAsync();

            foreach (var card in cards)
            {
                var cardPage = webClient.DownloadString(card.Url);

                await _extractor.ProcessPageAsync(cardPage, card);
            }
        }
    }
}
