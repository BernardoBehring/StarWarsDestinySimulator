using System.Collections.Generic;

namespace StarWarsDestiny.Model
{
    public class DiceAction : EntityId
    {
        public string Name { get; set; }
        public ICollection<DiceFace> DiceFaces { get; set; }
    }
}
