using System;

namespace StarWarsDestiny.Common.Model
{
    public class Audit
    {
        public DateTime InsertedIn { get; set; }
        public DateTime? UpdatedIn { get; set; }
        public DateTime? DeletedIn { get; set; }
    }
}
