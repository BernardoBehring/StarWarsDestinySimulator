using StarWarsDestiny.Common.Model;

namespace StarWarsDestiny.Model
{
    public class Upgrade : Card
    {
        public bool Exausted { get; set; }
        public bool CanBeExausted { get; set; }
    }
}
