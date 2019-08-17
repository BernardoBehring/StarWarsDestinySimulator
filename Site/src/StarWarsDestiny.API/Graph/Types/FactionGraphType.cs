using GraphQL.Types;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.API.Graph.Types
{
    public class FactionGraphType : ObjectGraphType<Faction>
    {
        public FactionGraphType()
        {
            Name = "FactionGraphType";

            Field(x => x.Id, false, typeof(IntGraphType));
            Field(x => x.Name, false, typeof(StringGraphType));
        }
    }
}
