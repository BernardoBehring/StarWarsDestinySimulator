namespace StarWarsDestiny.Model
{
    public class PlayerGame : PlayerAttributes
    {
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
