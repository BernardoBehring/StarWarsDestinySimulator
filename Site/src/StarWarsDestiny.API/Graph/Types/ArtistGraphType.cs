using GraphQL.Types;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.API.Graph.Types
{
    public class ArtistGraphType : ObjectGraphType<Artist>
    {
        public ArtistGraphType()
        {
            Name = "ArtistGraphType";
            Field(x => x.Id, false, typeof(IntGraphType));
            Field(x => x.Name, false, typeof(StringGraphType));
        }
    }
}
