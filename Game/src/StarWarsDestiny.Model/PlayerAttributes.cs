using StarWarsDestiny.Common.Model;
using System.Collections.Generic;

namespace StarWarsDestiny.Model
{
    public class PlayerAttributes : EntityId
    {
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public IList<Card> CardsInHand { get; set; }
        public IList<Card> Limbo { get; set; }
        public IList<RolledDice> DicePool { get; set; }
        public int Resources { get; set; }
        public IList<Character> Characters { get; set; }
        public IList<Suport> Suports { get; set; }
        public IList<Card> Deck { get; set; }
        public int PlotId { get; set; }
        public Card Plot { get; set; }
        public IList<Card> DiscardPile { get; set; }
        public IList<Card> CardsInPlay { get; set; }
    }
}
