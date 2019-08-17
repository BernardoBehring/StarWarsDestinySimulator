using StarWarsDestiny.Common.Model;
using StarWarsDestiny.Model.Enum;

namespace StarWarsDestiny.Model
{
    public class Keyword : EntityId
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public EnumKeyWords EnumKeyWords { get; set; }
    }
}
