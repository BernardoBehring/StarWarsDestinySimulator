using StarWarsDestiny.Common.Model;
using System.Collections.Generic;

namespace StarWarsDestiny.Crawler.Model
{
    public class Status : EntityId
    {
        public string Name { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}
