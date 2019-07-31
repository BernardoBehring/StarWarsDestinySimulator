using System.Collections.Generic;

namespace StarWarsDestiny.CrawlerModel
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}
