using StarWarsDestiny.Common.Model;
using StarWarsDestiny.Model.Interfaces;

namespace StarWarsDestiny.Model
{
    public class BalanceForce : EntityId, ICharacterAtributes
    {
        public int CardLegalityId { get; set; }
        public int Points { get; set; }
        public int? ElitePoints { get; set; }
        public int Health { get; set; }
        public CardLegality CardLegality { get; set; }
    }
}
