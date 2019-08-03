using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.Service.Impl
{
    public class DiceActionService : ModelOnlyNameService<DiceAction>, IDiceActionService
    {
        public DiceActionService(IReadWriteRepository<DiceAction> repository) : base(repository)
        {

        }
    }
}
