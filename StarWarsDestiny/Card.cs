using System.Collections.Generic;

namespace StarWarsDestiny.Model
{
    public class Card : EntityId
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public int Number { get; set; }
        public Artist Artist { get; set; }
        public Affiliation Affiliation { get; set; }
        public Color Color { get; set; }
        public ICollection<Type> Type { get; set; }
        public Rarity Rarity { get; set; }
        public Die Die { get; set; }
        public Set Set { get; set; }
        
        public ICollection<Keyword> Keywords { get; set; }
        public byte[] Image { get; set; }
        //TODO COLOCAR EM UM OUTRO LUGAR
        public ICollection<Legality> Legalities { get; set; }
        public ICollection<BalanceForce> BalanceForces { get; set; }
    }
}
