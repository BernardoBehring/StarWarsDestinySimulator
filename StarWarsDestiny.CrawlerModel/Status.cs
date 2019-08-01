using System.Collections.Generic;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Crawler.Model
{
    public class Status : EntityId
    {
        public string Name { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}
