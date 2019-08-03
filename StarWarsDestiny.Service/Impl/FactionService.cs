using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.Service.Impl
{
    public class FactionService : ModelOnlyNameService<Faction>, IFactionService
    {
        public FactionService(IReadWriteRepository<Faction> repository) : base(repository)
        {

        }
    }
}
