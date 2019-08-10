using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Service.Impl;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.Service.Impl
{
    public class GameService : ReadWriteService<Game, StarWarsDestinyContext>, IGameService
    {
        public GameService(IReadWriteRepository<Game, StarWarsDestinyContext> repository) : base(repository)
        {
        }
    }
}
