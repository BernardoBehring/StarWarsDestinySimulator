using System.Collections.Generic;
using StarWarsDestiny.Common.Model;
using StarWarsDestiny.Model.Interfaces;

namespace StarWarsDestiny.Model
{
    public class Card : EntityId, ICharacterAtributes, INonCharacterAtributes
    {
        public string Name { get; set; }
        public string Subtitle { get; set; }
        public string Text { get; set; }
        public int Number { get; set; }
        public int? ArtistId { get; set; }
        public int AffiliationId { get; set; }
        public int FactionId { get; set; }
        public int ColorId { get; set; }
        public int RarityId { get; set; }
        public int? DieId { get; set; }
        public int SetStarWarsId { get; set; }
        public string Url { get; set; }
        public string UrlImage { get; set; }
        public string DataCode { get; set; }
        public int? Points { get; set; }
        public int? ElitePoints { get; set; }
        public int? Health { get; set; }
        public int? Cost { get; set; }
        public bool IsCharacter { get; set; }
        public bool? IsUnique { get; set; }
        public string Flavor { get; set; }
        public string Image { get; set; }
        public SetStarWars SetStarWars { get; set; }
        public Die Die { get; set; }
        public Rarity Rarity { get; set; }
        public Color Color { get; set; }
        public Faction Faction { get; set; }
        public Affiliation Affiliation { get; set; }
        public Artist Artist { get; set; }
        public ICollection<CardType> CardTypes { get; set; }
        public ICollection<Keyword> Keywords { get; set; }
        public ICollection<CardLegality> CardLegalities { get; set; }
    }
}
