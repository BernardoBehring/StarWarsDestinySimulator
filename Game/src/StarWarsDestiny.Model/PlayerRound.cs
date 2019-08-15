using StarWarsDestiny.Common.Model;
using System.Collections.Generic;

namespace StarWarsDestiny.Model
{
    public class PlayerRound : EntityId
    {
        public int PlayerGameId { get; set; }
        public int RoundGameId { get; set; }
        public int Resources { get; set; }
        public RoundGame RoundGame { get; set; }
        public PlayerGame PlayerGame { get; set; }
        public IList<PlayerRoundCardInHand> CardsInHand { get; set; }
        public IList<PlayerRoundCardInLimbo> Limbo { get; set; }
        public IList<PlayerRoundRolledDice> DicePool { get; set; }
        public IList<PlayerRoundCardInDiscard> DiscardPile { get; set; }
        public IList<PlayerRoundCardInPlay> CardsInPlay { get; set; }
    }
}
