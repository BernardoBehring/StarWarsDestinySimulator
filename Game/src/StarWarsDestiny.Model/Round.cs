using StarWarsDestiny.Common.Model;

namespace StarWarsDestiny.Model
{
    public class Round : EntityId
    {
        public int? UpkeepPhaseId { get; set; }
        public int? ActionPhaseId { get; set; }
        public bool BattleFieldClaimed { get; set; }
        public int? PlayerGameIdClaimedBattlefield { get; set; }
        public UpkeepPhase UpkeepPhase { get; set; }
        public ActionPhase ActionPhase { get; set; }
        public PlayerGame PlayerGameClaimedBattleField { get; set; }
    }
}
