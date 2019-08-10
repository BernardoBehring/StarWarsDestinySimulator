using StarWarsDestiny.Common.Model;

namespace StarWarsDestiny.Model
{
    public class RolledDice : EntityId
    {
        public int DieId { get; set; }
        public int DiceFaceId { get; set; }
        public Die Die { get; set; }
        public DiceFace DiceFace { get; set; }
    }
}
