using StarWarsDestiny.Common.Model;

namespace StarWarsDestiny.Model
{
    public class UpkeepPhase : EntityId
    {
        public int RoundId { get; set; }
        public Round Round { get; set; }
    }
}
