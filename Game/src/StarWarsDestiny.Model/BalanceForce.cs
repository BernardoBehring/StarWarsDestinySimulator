using StarWarsDestiny.Common.Model;
using StarWarsDestiny.Model.Interfaces;

namespace StarWarsDestiny.Model
{
    public class BalanceForce : EntityId, ICharacterAtributes
    {
        public int CardId { get; set; }
        public int LegalityId { get; set; }
        public Card Card { get; set; }
        public Legality Legality { get; set; }
        public int Points { get; set; }
        public int? ElitePoints { get; set; }
        public int Health { get; set; }
    }
}
