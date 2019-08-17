using StarWarsDestiny.Common.Model;

namespace StarWarsDestiny.Model
{
    public class PlayerRoundCardInPlayUpgrade : EntityId
    {
        public int PlayerRoundCardInPlayId { get; set; }
        public bool Exausted { get; set; }
        public bool CanBeExausted { get; set; }
        public PlayerRoundCardInPlay PlayerRoundCardInPlay { get; set; }
    }
}
