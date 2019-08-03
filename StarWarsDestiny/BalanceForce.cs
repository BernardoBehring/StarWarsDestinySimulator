namespace StarWarsDestiny.Model
{
    public class BalanceForce : EntityId
    {
        public int CardId { get; set; }
        public int LegalityId { get; set; }
        public Card Card { get; set; }
        public Legality Legality { get; set; }
        public CharacterAtributes CharacterAtributes { get; set; }
    }
}
