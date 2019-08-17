using GraphQL.Types;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.API.Graph.Types
{
    public class RarityGraphType : ObjectGraphType<Rarity>
    {
        public RarityGraphType()
        {
            Name = "RarityGraphType";

            Field(x => x.Id, false, typeof(IntGraphType));
            Field(x => x.Name, false, typeof(StringGraphType));
        }
    }
}
