using System.Collections.Generic;
using StarWarsDestiny.Common.Model;

namespace StarWarsDestiny.Model
{
    public class Suport : EntityId
    {
        public int CardId { get; set; }
        public Card Card { get; set; }
        public bool Exausted { get; set; }
        public IEnumerable<Upgrade> Upgrades { get; set; }
    }
}
