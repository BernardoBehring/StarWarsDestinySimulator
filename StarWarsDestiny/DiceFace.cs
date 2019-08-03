namespace StarWarsDestiny.Model
{
    public class DiceFace : EntityId
    {
        public int Value { get; set; }
        public bool IsModifier { get; set; }
        public DiceAction DiceAction { get; set; }
        public int Cost { get; set; }
    }
}
