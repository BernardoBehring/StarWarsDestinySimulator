using System.Collections.Generic;
using StarWarsDestiny.Common.Model;

namespace StarWarsDestiny.Model
{
    public class Game : EntityId
    {
        public Battlefield Battlefield { get; set; }
        public SetUp SetUp { get; set; }
        public IEnumerable<Round> Rounds { get; set; }
        public ICollection<PlayerGame> Players { get; set; }
    }
}
