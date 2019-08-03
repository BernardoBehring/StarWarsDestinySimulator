using StarWarsDestiny.Common.Repository.Impl;
using StarWarsDestiny.Crawler.Model;
using StarWarsDestiny.Crawler.Repository.Context;
using StarWarsDestiny.Crawler.Repository.Interfaces;

namespace StarWarsDestiny.Crawler.Repository.Impl
{
    public class StatusRepository : ReadWriteRepository<Status, CrawlerContext>, IStausRepository
    {
        public StatusRepository(CrawlerContext context) : base(context)
        {
        }
    }
}
