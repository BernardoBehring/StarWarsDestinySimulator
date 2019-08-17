using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Service.Impl;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.Service.Impl
{
    public class DiceFaceService : ReadWriteService<DiceFace, StarWarsDestinyContext>, IDiceFaceService
    {
        public DiceFaceService(IReadWriteRepository<DiceFace, StarWarsDestinyContext> repository) : base(repository)
        {

        }
    }
}
