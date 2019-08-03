using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.Service.Impl
{
    public class ColorService : ModelOnlyNameService<Color>, IColorService
    {
        public ColorService(IReadWriteRepository<Color> repository) : base(repository)
        {

        }
    }
}
