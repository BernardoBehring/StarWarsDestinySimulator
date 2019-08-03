using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.Service.Impl
{
    public class SetStarWarsService : ModelOnlyNameService<SetStarWars>, ISetStarWarsService
    {

        public SetStarWarsService(IReadWriteRepository<SetStarWars> repository) : base(repository)
        {
            
        }
    }
}
