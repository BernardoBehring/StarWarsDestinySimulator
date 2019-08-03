using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.Service.Impl
{
    public class RarityService : ModelOnlyNameService<Rarity>, IRarityService
    {
        public RarityService(IReadWriteRepository<Rarity> repository) : base(repository)
        {
            
        }
    }
}
