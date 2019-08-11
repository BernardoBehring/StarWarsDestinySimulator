using System.Collections.Generic;
using StarWarsDestiny.Model.Common;

namespace StarWarsDestiny.Model
{
    public class Deck : ModelOnlyName
    {
        public ICollection<Card> Cards { get; set; }
    }
}
