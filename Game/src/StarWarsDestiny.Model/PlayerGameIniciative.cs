using StarWarsDestiny.Common.Model;

namespace StarWarsDestiny.Model
{
    public class PlayerGameIniciative : EntityId
    {
        public int SetUpId { get; set; }
        public int PlayerGameId { get; set; }
        public int Iniciative { get; set; }
        public SetUp SetUp { get; set; }
        public PlayerGame PlayerGame { get; set; }
    }
}
