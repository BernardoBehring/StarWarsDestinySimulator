using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Service.Impl;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.Service.Impl
{
    public class DieService : ReadWriteService<Die, StarWarsDestinyContext>, IDieService
    {
        public DieService(IReadWriteRepository<Die, StarWarsDestinyContext> repository) : base(repository)
        {

        }
    }
}
