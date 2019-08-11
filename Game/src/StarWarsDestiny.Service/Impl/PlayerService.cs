using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.Service.Impl
{
    public class PlayerService : ModelOnlyNameService<Player, StarWarsDestinyContext>, IPlayerService
    {
        public PlayerService(IReadWriteRepository<Player, StarWarsDestinyContext> repository) : base(repository)
        {
        }
    }
}
