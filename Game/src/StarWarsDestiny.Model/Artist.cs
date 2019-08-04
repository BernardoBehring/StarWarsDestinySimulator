using StarWarsDestiny.Model.Common;
using System.Collections.Generic;

namespace StarWarsDestiny.Model
{
    public class Artist : ModelOnlyName
    {
        public ICollection<Card> Cards { get; set; }
    }
}
