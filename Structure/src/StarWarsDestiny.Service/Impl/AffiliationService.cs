using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.Service.Impl
{
    public class AffiliationService : ModelOnlyNameService<Affiliation, StarWarsDestinyContext>, IAffiliationService
    {
        public AffiliationService(IReadWriteRepository<Affiliation, StarWarsDestinyContext> repository) : base(repository)
        {

        }
    }
}
