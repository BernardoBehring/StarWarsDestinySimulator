using StarWarsDestiny.Model.Common;
using System.Collections.Generic;
using StarWarsDestiny.Model.Enum;

namespace StarWarsDestiny.Model
{
    public class Type : ModelOnlyName
    {
        //public EnumType EnumType { get; set; }
        public ICollection<CardType> CardTypes { get; set; }
    }
}
