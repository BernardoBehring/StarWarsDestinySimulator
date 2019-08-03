
using System.Collections.Generic;

namespace StarWarsDestiny.Model
{
    public class DiceFace : EntityId
    {
        public int Value { get; set; }
        public bool IsModifier { get; set; }
        public int DiceActionId { get; set; }
        public int Cost { get; set; }
        public int DieId { get; set; }
        public DiceAction DiceAction { get; set; }
        public Die Die { get; set; }
    }
}
