using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.Service.Impl
{
    public class ColorService : ModelOnlyNameService<Color, StarWarsDestinyContext>, IColorService
    {
        public ColorService(IReadWriteRepository<Color, StarWarsDestinyContext> repository) : base(repository)
        {

        }
    }
}
