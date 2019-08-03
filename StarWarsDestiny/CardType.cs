namespace StarWarsDestiny.Model
{
    public class CardType : EntityId
    {
        public int CardId { get; set; }
        public int TypeId { get; set; }
        public Card Card { get; set; }
        public Type Type { get; set; }
    }
}
