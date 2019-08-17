using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.Service.Impl
{
    public class LegalityService : ModelOnlyNameService<Legality, StarWarsDestinyContext>, ILegalityService
    {
        public LegalityService(IReadWriteRepository<Legality, StarWarsDestinyContext> repository) : base(repository)
        {

        }
    }
}
