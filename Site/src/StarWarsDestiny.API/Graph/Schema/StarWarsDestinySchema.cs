using GraphQL;

namespace StarWarsDestiny.API.Graph.Schema
{
    public class StarWarsDestinySchema : GraphQL.Types.Schema
    {
        public StarWarsDestinySchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<Query>();
        }
    }
}
