using StarWarsDestiny.Common.Service.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;

namespace StarWarsDestiny.Service.Interfaces
{
    public interface IActionService : IReadWriteService<Action, StarWarsDestinyContext>, IModelOnlyNameService
    {
    }
}
