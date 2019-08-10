using System.Collections.Generic;
using StarWarsDestiny.Common.Model;

namespace StarWarsDestiny.Model
{
    public class ActionPhase : EntityId
    {
        public IEnumerable<Turn> Turn { get; set; }
    }
}
