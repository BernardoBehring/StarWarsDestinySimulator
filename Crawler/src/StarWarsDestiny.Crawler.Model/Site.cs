using StarWarsDestiny.Common.Model;
using System.Collections.Generic;

namespace StarWarsDestiny.Crawler.Model
{
    public class Site : EntityId
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public ICollection<Robot> Robots { get; set; }
    }
}
