using System.Collections.Generic;

namespace StarWarsDestiny.CrawlerModel
{
    public class RobotType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Robot> Robots { get; set; }
    }
}
