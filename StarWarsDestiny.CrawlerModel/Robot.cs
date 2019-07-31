using System.Collections.Generic;

namespace StarWarsDestiny.CrawlerModel
{
    public class Robot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RobotTypeId { get; set; }
        public int SiteId { get; set; }
        public ICollection<Request> Requests { get; set; }
        public Site Site { get; set; }
        public RobotType RobotType { get; set; }
    }
}
