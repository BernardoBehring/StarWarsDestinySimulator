using System.Collections.Generic;
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
        public ICollection<PlayerGameCharacterShield> PlayerGameCharacterShields { get; set; }
        public ICollection<PlayerGameIniciative> PlayerGameIniciatives { get; set; }
        public ICollection<PlayerRound> PlayerRounds { get; set; }
        public ICollection<Round> RoundsClaimedBattleField { get; set; }
    }
}
