using GraphQL.Types;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.API.Graph.Types
{
    public class AffiliationGraphType : ObjectGraphType<Affiliation>
    {
        public AffiliationGraphType()
        {
            Name = "AffiliationGraphType";
            Field(x => x.Id, false, typeof(IntGraphType));
            Field(x => x.Name, false, typeof(StringGraphType));
        }
    }
}
