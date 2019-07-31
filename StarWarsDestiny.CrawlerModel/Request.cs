using System;

namespace StarWarsDestiny.CrawlerModel
{
    public class Request
    {
        public long Id { get; set; }
        public int StatusId { get; set; }
        public int RobotId { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? StartDateExecution { get; set; }
        public DateTime? EndDateExecution { get; set; }
        public string Response { get; set; }
        public int? AttemptQty { get; set; }
        public virtual Robot Robot { get; set; }
        public virtual Status Status { get; set; }
    }
}
