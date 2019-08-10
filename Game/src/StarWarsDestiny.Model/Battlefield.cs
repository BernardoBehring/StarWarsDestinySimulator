using StarWarsDestiny.Common.Model;

namespace StarWarsDestiny.Model
{
    public class Battlefield : EntityId
    {
        public int BattlefieldId { get; set; }
        public Card BattlefieldCard { get; set; }
    }
}
