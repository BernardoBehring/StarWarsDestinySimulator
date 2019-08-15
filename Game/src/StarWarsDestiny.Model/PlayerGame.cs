using StarWarsDestiny.Common.Model;

namespace StarWarsDestiny.Model
{
    public class PlayerGame : EntityId
    {
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public int DeckId { get; set; }
        public Game Game { get; set; }
        public Player Player { get; set; }
        public Deck Deck { get; set; }
    }
}
