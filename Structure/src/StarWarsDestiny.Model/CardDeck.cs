using StarWarsDestiny.Common.Model;

namespace StarWarsDestiny.Model
{
    public class CardDeck : EntityId
    {
        public int CardId { get; set; }
        public int DeckId { get; set; }
        public Card Card { get; set; }
        public Deck Deck { get; set; }
    }
}
