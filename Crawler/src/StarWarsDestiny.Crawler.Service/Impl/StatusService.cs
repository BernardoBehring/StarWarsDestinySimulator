using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Service.Impl;
using StarWarsDestiny.Crawler.Model;
using StarWarsDestiny.Crawler.Repository.Context;
using StarWarsDestiny.Crawler.Service.Interfaces;

namespace StarWarsDestiny.Crawler.Service.Impl
{
    public class StatusService : ReadWriteService<Status, CrawlerContext>, IStatusService
    {
        public StatusService(IReadWriteRepository<Status, CrawlerContext> repository) : base(repository)
        {
        }
    }
}
