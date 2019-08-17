using GraphQL.Types;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.API.Graph.Types
{
    public class DieGraphType : ObjectGraphType<Die>
    {
        public DieGraphType()
        {
            Name = "DieGraphType";

            Field(x => x.Id, false, typeof(IntGraphType));
            Field(x => x.DiceFaces, true, typeof(ListGraphType<DiceFaceGraphType>));
        }
    }
}
