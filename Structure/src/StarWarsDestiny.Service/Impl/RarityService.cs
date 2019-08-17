using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.Service.Impl
{
    public class RarityService : ModelOnlyNameService<Rarity, StarWarsDestinyContext>, IRarityService
    {
        public RarityService(IReadWriteRepository<Rarity, StarWarsDestinyContext> repository) : base(repository)
        {
            
        }
    }
}
