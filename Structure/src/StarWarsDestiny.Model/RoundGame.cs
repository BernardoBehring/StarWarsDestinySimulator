using System.Collections.Generic;
using StarWarsDestiny.Common.Model;

namespace StarWarsDestiny.Model
{
    public class RoundGame : EntityId
    {
        public int RoundId { get; set; }
        public int GameId { get; set; }
        public Round Round { get; set; }
        public Game Game { get; set; }
        public ICollection<PlayerRound> PlayerRounds { get; set; }
    }
}
