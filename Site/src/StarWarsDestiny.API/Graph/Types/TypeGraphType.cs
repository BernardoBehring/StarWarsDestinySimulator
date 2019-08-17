using GraphQL.Types;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.API.Graph.Types
{
    public class TypeGraphType : ObjectGraphType<Type>
    {
        public TypeGraphType()
        {
            Name = "TypeGraphType";

            Field(x => x.Id, false, typeof(IntGraphType));
            Field(x => x.Name, false, typeof(StringGraphType));
        }
    }
}
