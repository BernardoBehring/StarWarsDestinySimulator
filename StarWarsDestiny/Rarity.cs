using System.Collections.Generic;

namespace StarWarsDestiny.Model
{
    public class Rarity : EntityId
    {
        public string Name { get; set; }
        public ICollection<Card> Cards { get; set; }
    }
}
