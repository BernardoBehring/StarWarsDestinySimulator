namespace StarWarsDestiny.Model.Dto
{
    public class CardFilter
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Subtitle { get; set; }
        public string Text { get; set; }
        public int? Number { get; set; }
        public int? ArtistId { get; set; }
        public int? AffiliationId { get; set; }
        public int? FactionId { get; set; }
        public int? ColorId { get; set; }
        public int? RarityId { get; set; }
        public int? SetStarWarsId { get; set; }
        public int? Points { get; set; }
        public int? ElitePoints { get; set; }
        public int? Health { get; set; }
        public int? Cost { get; set; }
        public bool? IsCharacter { get; set; }
        public bool? IsSuport { get; set; }
        public bool? IsUpgrade { get; set; }
        public bool? IsUnique { get; set; }
    }
}
