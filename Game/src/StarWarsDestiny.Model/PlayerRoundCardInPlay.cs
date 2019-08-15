using StarWarsDestiny.Common.Model;
using System.Collections.Generic;

namespace StarWarsDestiny.Model
{
    public class PlayerRoundCardInPlay : EntityId
    {
        public int PlayerRoundId { get; set; }
        public int CardId { get; set; }
        public bool Exausted { get; set; }
        public PlayerRound PlayerRound { get; set; }
        public Card Card { get; set; }
        public IEnumerable<PlayerRoundCardInPlayUpgrade> Upgrades { get; set; }
    }
}
