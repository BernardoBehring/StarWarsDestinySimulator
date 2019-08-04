using StarWarsDestiny.Common.Model;
using System.Collections.Generic;

namespace StarWarsDestiny.Model
{
    public class Die : EntityId
    {
        public int CardId { get; set; }
        public Card Card { get; set; }
        public ICollection<DiceFace> DiceFaces { get; set; }
    }
}
