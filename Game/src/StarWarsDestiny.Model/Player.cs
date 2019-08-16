using StarWarsDestiny.Model.Common;
using System.Collections.Generic;

namespace StarWarsDestiny.Model
{
    public class Player : ModelOnlyName
    {
        public ICollection<PlayerGame> PlayerGames { get; set; }
    }
}
