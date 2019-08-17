
using StarWarsDestiny.Common.Model;
using System.Collections.Generic;

namespace StarWarsDestiny.Model
{
    public class CardLegality : EntityId
    {
        public int CardId { get; set; }
        public int LegalityId { get; set; }
        public bool IsLegal { get; set; }
        public Card Card { get; set; }
        public Legality Legality { get; set; }
        public ICollection<BalanceForce> BalanceForces { get; set; }
    }
}
