using StarWarsDestiny.Common.Model;

namespace StarWarsDestiny.Model
{
    public class PlayerRoundCardInDiscard : EntityId
    {
        public int PlayerRoundId { get; set; }
        public int CardId { get; set; }
        public PlayerRound PlayerRound { get; set; }
        public Card Card { get; set; }
    }
}
