using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.Service.Impl
{
    public class DiceActionService : ModelOnlyNameService<DiceAction, StarWarsDestinyContext>, IDiceActionService
    {
        public DiceActionService(IReadWriteRepository<DiceAction, StarWarsDestinyContext> repository) : base(repository)
        {

        }
    }
}
