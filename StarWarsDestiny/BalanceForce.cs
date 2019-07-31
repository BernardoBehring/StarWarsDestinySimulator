namespace StarWarsDestiny.Model
{
    public class BalanceForce : EntityId
    {
        public Card Card { get; set; }
        public Legality Legality { get; set; }
        public CharacterAtributes CharacterAtributes { get; set; }
    }
}
