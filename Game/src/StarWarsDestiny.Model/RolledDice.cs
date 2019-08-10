using StarWarsDestiny.Common.Model;

namespace StarWarsDestiny.Model
{
    public class RolledDice : Die
    {
        public int DiceFaceId { get; set; }
        public DiceFace DiceFace { get; set; }
    }
}
