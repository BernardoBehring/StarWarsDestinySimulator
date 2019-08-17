using StarWarsDestiny.Model.Common;
using System.Collections.Generic;

namespace StarWarsDestiny.Model
{
    public class DiceAction : ModelOnlyName
    {
        public ICollection<DiceFace> DiceFaces { get; set; }
    }
}
