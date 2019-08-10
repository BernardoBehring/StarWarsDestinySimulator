using System.Collections.Generic;

namespace StarWarsDestiny.Model
{
    public class Suport : Card
    {
        public bool Exausted { get; set; }
        public IEnumerable<Upgrade> Upgrades { get; set; }
    }
}
