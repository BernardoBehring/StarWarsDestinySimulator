using StarWarsDestiny.Common.Model;
using System.Collections.Generic;

namespace StarWarsDestiny.Crawler.Model
{
    public class Robot : EntityId
    {
        public string Name { get; set; }
        public int RobotTypeId { get; set; }
        public int SiteId { get; set; }
        public ICollection<Request> Requests { get; set; }
        public Site Site { get; set; }
        public RobotType RobotType { get; set; }
    }
}
