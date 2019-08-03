using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.Service.Impl
{
    public class FactionService : ModelOnlyNameService<Faction, StarWarsDestinyContext>, IFactionService
    {
        public FactionService(IReadWriteRepository<Faction, StarWarsDestinyContext> repository) : base(repository)
        {

        }
    }
}
