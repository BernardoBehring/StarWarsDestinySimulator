using GraphQL.Types;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.API.Graph.Types
{
    public class SetStarWarsGraphType : ObjectGraphType<SetStarWars>
    {
        public SetStarWarsGraphType()
        {
            Name = "SetStarWarsGraphType";

            Field(x => x.Id, false, typeof(IntGraphType));
            Field(x => x.Name, false, typeof(StringGraphType));
        }
    }
}
