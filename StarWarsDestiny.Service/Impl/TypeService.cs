using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.Service.Impl
{
    public class TypeService : ModelOnlyNameService<Type>, ITypeService
    {
        public TypeService(IReadWriteRepository<Type> repository) : base(repository)
        {

        }
    }
}
