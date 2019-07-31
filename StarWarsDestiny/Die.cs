
using System.Collections.Generic;

namespace StarWarsDestiny.Model
{
    public class Die : EntityId
    {
        public Card Card { get; set; }
        public ICollection<DiceFace> Faces { get; set; }
    }
}
