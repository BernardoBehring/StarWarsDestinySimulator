using StarWarsDestiny.Common.Model;
using System.Collections.Generic;

namespace StarWarsDestiny.Crawler.Model
{
    public class RobotType : EntityId
    {
        public string Name { get; set; }
        public virtual ICollection<Robot> Robots { get; set; }
    }
}
