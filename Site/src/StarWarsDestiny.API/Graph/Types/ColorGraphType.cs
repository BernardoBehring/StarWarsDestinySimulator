using GraphQL.Types;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.API.Graph.Types
{
    public class ColorGraphType : ObjectGraphType<Color>
    {
        public ColorGraphType()
        {
            Name = "ColorGraphType";
            Field(x => x.Id, false, typeof(IntGraphType));
            Field(x => x.Name, false, typeof(StringGraphType));
        }
    }
}
