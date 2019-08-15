using System.Collections.Generic;
using StarWarsDestiny.Common.Model;

namespace StarWarsDestiny.Model
{
    public class SetUp : EntityId
    {
        public int GameId { get; set; }
        public int BattlefieldChoosedId { get; set; }
        public IEnumerable<PlayerGameCharacterShield> ShieldsGiven { get; set; }
        public IEnumerable<PlayerGameIniciative> PlayersIniciatives { get; set; }
        public Battlefield BattlefieldChoosed { get; set; }
        public Game Game { get; set; }
    }
}
