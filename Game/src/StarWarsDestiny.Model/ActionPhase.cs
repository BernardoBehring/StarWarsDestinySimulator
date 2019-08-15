using System.Collections.Generic;
using StarWarsDestiny.Common.Model;

namespace StarWarsDestiny.Model
{
    public class ActionPhase : EntityId
    {
        public int GameId { get; set; }
        public Game Game { get; set; }
        public IEnumerable<Turn> Turn { get; set; }
    }
}
