using System.Collections.Generic;
using StarWarsDestiny.Common.Model;

namespace StarWarsDestiny.Model
{
    public class Game : EntityId
    {
        public int BattleFieldId { get; set; }
        public int SetUpId { get; set; }
        public Battlefield Battlefield { get; set; }
        public SetUp SetUp { get; set; }
        public IEnumerable<RoundGame> Rounds { get; set; }
        public ICollection<PlayerGame> Players { get; set; }
        public ICollection<Battlefield> Battlefields { get; set; }
    }
}
