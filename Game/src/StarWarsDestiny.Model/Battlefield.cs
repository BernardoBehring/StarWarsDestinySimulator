using System.Collections.Generic;
using StarWarsDestiny.Common.Model;

namespace StarWarsDestiny.Model
{
    public class Battlefield : EntityId
    {
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int BattlefieldCardId { get; set; }
        public Card BattlefieldCard { get; set; }
        public ICollection<SetUp> SetUps { get; set; }
    }
}
