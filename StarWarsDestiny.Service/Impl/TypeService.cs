using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.Service.Impl
{
    public class TypeService : ModelOnlyNameService<Type, StarWarsDestinyContext>, ITypeService
    {
        public TypeService(IReadWriteRepository<Type, StarWarsDestinyContext> repository) : base(repository)
        {

        }
    }
}
