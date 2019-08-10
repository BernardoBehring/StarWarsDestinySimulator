using StarWarsDestiny.Common.Model;
using System.Collections.Generic;

namespace StarWarsDestiny.Model
{
    public class PlayerAttributes : EntityId
    {
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public IEnumerable<Card> CardsInHand { get; set; }
        public IEnumerable<Card> Limbo { get; set; }
        public IEnumerable<RolledDice> DicePool { get; set; }
        public int Resources { get; set; }
        public IEnumerable<Character> Characters { get; set; }
        public IEnumerable<Suport> Suports { get; set; }
        public IEnumerable<Card> Deck { get; set; }
        public int PlotId { get; set; }
        public Card Plot { get; set; }
        public IEnumerable<Card> DiscardPile { get; set; }
        public IEnumerable<Card> CardsInPlay { get; set; }
    }
}
