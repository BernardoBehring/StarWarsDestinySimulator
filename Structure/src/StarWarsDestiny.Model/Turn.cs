using StarWarsDestiny.Common.Model;

namespace StarWarsDestiny.Model
{
    public class Turn : EntityId
    {
        public int Number { get; set; }
        public int ActionPhaseId { get; set; }
        public ActionPhase ActionPhase { get; set; }
    }
}
