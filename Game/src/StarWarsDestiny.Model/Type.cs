using StarWarsDestiny.Model.Common;
using System.Collections.Generic;

namespace StarWarsDestiny.Model
{
    public class Type : ModelOnlyName
    {
        public ICollection<CardType> CardTypes { get; set; }
    }
}
