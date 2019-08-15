using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using System.Threading.Tasks;
using StarWarsDestiny.Crawler.Deck.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.Crawler.Deck.Extractor
{
    public class DownloadDeckDetailsSWDestinyDBExtractor : IDownloadDeckDetailsSWDestinyDBExtractor
    {
        private readonly ICardService _cardService;
        private readonly ICardDeckService _cardDeckService;

        public DownloadDeckDetailsSWDestinyDBExtractor(ICardService cardService, ICardDeckService cardDeckService)
        {
            _cardService = cardService;
            _cardDeckService = cardDeckService;
        }

        public async Task ProcessPageAsync(string page, object obj)
        {
            var deck = (StarWarsDestiny.Model.Deck) obj;
            var document = new HtmlDocument();
            document.LoadHtml(page);

            var div = document.DocumentNode.SelectSingleNode("//div[@id='deck-content']/div[@class='deck-content']");

            var cardBattleField = await GetBattleField(div);
            var listCharacters = new List<Card>();
            var listCards = new List<Card>();

            await GetCharacters(div, listCharacters);

            await GetCards(div, listCards);

            var listAllCards = new List<Card>
            {
                cardBattleField
            };
            listAllCards.AddRange(listCharacters);
            listAllCards.AddRange(listCards);

            foreach (var card in listAllCards)
            {
                var deckCard = new CardDeck
                {
                    InsertedIn = DateTime.Now,
                    CardId = card.Id,
                    DeckId = deck.Id
                };
                await _cardDeckService.CreateAsync(deckCard);
            }
        }

        private async Task GetCards(HtmlNode div, List<Card> listCards)
        {
            var divCards = div.SelectNodes("./div[@class='row'").LastOrDefault();

            var linkCards = divCards.SelectNodes("div/div/div/a");

            foreach (var link in linkCards)
            {
                var card = await GetCardByLink(link);
                listCards.Add(card);
            }
        }

        private async Task GetCharacters(HtmlNode div, List<Card> listCharacters)
        {
            var divCharacterList = div.SelectSingleNode("./div[@class='character-deck-list']");

            var listDivCharacters = divCharacterList.SelectNodes("./div[@class='deck-character']");

            foreach (var divCharacter in listDivCharacters)
            {
                var divCharacterName = divCharacter.SelectSingleNode("./div[@class='character-name']");

                var character = await GetCard(divCharacterName);

                listCharacters.Add(character);
            }
        }

        private async Task<Card> GetCard(HtmlNode div)
        {
            var link = div.SelectSingleNode("./a");

            return await GetCardByLink(link);
        }

        private async Task<Card> GetCardByLink(HtmlNode link)
        {
            var dataCode = link.Attributes["data-code"].Value;

            return await _cardService.GetCardByDataCode(dataCode);
        }

        private async Task<Card> GetBattleField(HtmlNode div)
        {
            var divBattleField = div.SelectSingleNode("./div/div[@class='deck-battlefield']");

            var divBattleFieldDetails = divBattleField.SelectNodes("./div")[1];

            return await GetCard(divBattleFieldDetails);
        }
    }
}
