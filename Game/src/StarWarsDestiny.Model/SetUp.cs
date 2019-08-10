using System.Collections.Generic;
using StarWarsDestiny.Common.Model;

namespace StarWarsDestiny.Model
{
    public class SetUp : EntityId
    {
        public IEnumerable<CharacterShield> ShieldsGiven { get; set; }
        public IEnumerable<PlayerIniciative> PlayersIniciatives { get; set; }
        public int BattlefieldChoosedId { get; set; }
        public Battlefield BattlefieldChoosed { get; set; }
    }
}
