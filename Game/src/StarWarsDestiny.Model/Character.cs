using System.Collections.Generic;

namespace StarWarsDestiny.Model
{
    public class Character : Card
    {
        public IEnumerable<Upgrade> Upgrades { get; set; }
        public bool Exausted { get; set; }
    }
}
