using System.Collections.Generic;
using StarWarsDestiny.Model.Common;

namespace StarWarsDestiny.Model
{
    public class Deck : ModelOnlyName
    {
        public string Url { get; set; }
        public ICollection<CardDeck> CardDecks { get; set; }
    }
}
