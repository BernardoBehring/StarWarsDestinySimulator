using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.Service.Impl
{
    public class AffiliationService : ModelOnlyNameService<Affiliation>, IAffiliationService
    {
        public AffiliationService(IReadWriteRepository<Affiliation> repository) : base(repository)
        {

        }
    }
}
