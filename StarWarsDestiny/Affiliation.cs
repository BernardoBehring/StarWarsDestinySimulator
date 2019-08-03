using System.Collections.Generic;

namespace StarWarsDestiny.Model
{
    public class Affiliation : EntityId
    {
        public string Name { get; set; }
        public ICollection<Card> Cards { get; set; }
    }
}
