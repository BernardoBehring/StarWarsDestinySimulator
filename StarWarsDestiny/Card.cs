using System.Collections.Generic;

namespace StarWarsDestiny.Model
{
    public class Card : EntityId
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public int Number { get; set; }
        public int ArtistId { get; set; }
        public int AffiliationId { get; set; }
        public int FactionId { get; set; }
        public int ColorId { get; set; }
        public int RarityId { get; set; }
        public int DieId { get; set; }
        public int SetStarWarsId { get; set; }
        public string Url { get; set; }
        public string DataCode { get; set; }
        public SetStarWars SetStarWars { get; set; }
        public Die Die { get; set; }
        public Rarity Rarity { get; set; }
        public Color Color { get; set; }
        public Faction Faction { get; set; }
        public Affiliation Affiliation { get; set; }
        public Artist Artist { get; set; }
        public ICollection<Type> Types { get; set; }
        public ICollection<Keyword> Keywords { get; set; }
        public byte[] Image { get; set; }
        //TODO COLOCAR EM UM OUTRO LUGAR
        public ICollection<Legality> Legalities { get; set; }
        public ICollection<BalanceForce> BalanceForces { get; set; }
    }
}
