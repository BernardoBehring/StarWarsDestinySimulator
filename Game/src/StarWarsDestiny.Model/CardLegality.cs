
using StarWarsDestiny.Common.Model;

namespace StarWarsDestiny.Model
{
    public class CardLegality : EntityId
    {
        public int CardId { get; set; }
        public int LegalityId { get; set; }
        public bool IsLegal { get; set; }
        public Card Card { get; set; }
        public Legality Legality { get; set; }
        public BalanceForce BalanceForce { get; set; }
    }
}
