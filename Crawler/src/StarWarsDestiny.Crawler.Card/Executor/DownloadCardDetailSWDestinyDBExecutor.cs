using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using StarWarsDestiny.Crawler.Card.Interfaces;
using StarWarsDestiny.Service.Interfaces;


namespace StarWarsDestiny.Crawler.Card.Executer
{
    public class DownloadCardDetailSWDestinyDBExecutor : IDownloadCardDetailSWDestinyDBExecutor
    {
        private readonly IDownloadCardDetailSWDestinyDBExtractor _extractor;
        private readonly ICardService _cardService;

        public WebClient webClient { get; set; }
        public DownloadCardDetailSWDestinyDBExecutor(IDownloadCardDetailSWDestinyDBExtractor extractor,
            ICardService cardService)
        {
            _extractor = extractor;
            _cardService = cardService;
            webClient = new WebClient();
        }

        public async Task ExecuteAsync()
        {
            var cards = await _cardService.GetAllAsync();

            var listCards = cards.Where(a => a.Image == null);

            foreach (var card in listCards)
            {
                var cardPage = webClient.DownloadString(card.Url);
                try
                {
                    await _extractor.ProcessPageAsync(cardPage, card);
                    if (card.UrlImage != null)
                    {
                        var image = webClient.DownloadData(card.UrlImage);
                        card.Image = Convert.ToBase64String(image);
                        await _cardService.PartialUpdateAsync(card, new[] {nameof(StarWarsDestiny.Model.Card.Image)});
                        Console.WriteLine($"Card [{card.Name}] image saved!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
