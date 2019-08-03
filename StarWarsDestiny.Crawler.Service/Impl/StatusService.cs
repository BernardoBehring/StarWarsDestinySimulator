using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Service.Impl;
using StarWarsDestiny.Crawler.Model;
using StarWarsDestiny.Crawler.Service.Interfaces;

namespace StarWarsDestiny.Crawler.Service.Impl
{
    public class StatusService : ReadWriteService<Status>, IStatusService
    {
        public StatusService(IReadWriteRepository<Status> repository) : base(repository)
        {
        }
    }
}
