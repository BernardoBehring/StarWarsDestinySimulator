using System.Collections.Generic;

namespace StarWarsDestiny.CrawlerModel
{
    public class Site
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public ICollection<Robot> Robots { get; set; }
    }
}
