using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.Service.Impl
{
    public class SetStarWarsService : ModelOnlyNameService<SetStarWars, StarWarsDestinyContext>, ISetStarWarsService
    {

        public SetStarWarsService(IReadWriteRepository<SetStarWars, StarWarsDestinyContext> repository) : base(repository)
        {
            
        }
    }
}
