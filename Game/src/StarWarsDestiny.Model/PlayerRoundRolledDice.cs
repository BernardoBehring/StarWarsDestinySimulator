using StarWarsDestiny.Common.Model;

namespace StarWarsDestiny.Model
{
    public class PlayerRoundRolledDice : EntityId
    {
        public int PlayerRoundId { get; set; }
        public int DieId { get; set; }
        public int DiceFaceId { get; set; }
        public PlayerRound PlayerRound { get; set; }
        public DiceFace DiceFace { get; set; }
        public Die Die { get; set; }
    }
}
