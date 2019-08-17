using StarWarsDestiny.Common.Model;

namespace StarWarsDestiny.Model
{
    public class PlayerGameCharacterShield : EntityId
    {
        public int SetUpId { get; set; }
        public int PlayerGameId { get; set; }
        public int CharacterCardId { get; set; }
        public int QtyShield { get; set; }
        public SetUp SetUp { get; set; }
        public PlayerGame PlayerGame { get; set; }
        public Card CharacterCard { get; set; }
    }
}
