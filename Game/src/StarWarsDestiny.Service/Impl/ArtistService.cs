using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.Service.Impl
{
    public class ArtistService : ModelOnlyNameService<Artist, StarWarsDestinyContext>, IArtistService
    {
        public ArtistService(IReadWriteRepository<Artist, StarWarsDestinyContext> repository) : base(repository)
        {

        }
    }
}
