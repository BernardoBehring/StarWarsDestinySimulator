using System.Collections.Generic;
using StarWarsDestiny.Common.Model;

namespace StarWarsDestiny.Model
{
    public class ActionPhase : EntityId
    {
        public int RoundId { get; set; }
        public Round Round { get; set; }
        public IEnumerable<Turn> Turn { get; set; }
    }
}
