using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Service.Impl;
using StarWarsDestiny.Crawler.Model;
using StarWarsDestiny.Crawler.Repository.Context;
using StarWarsDestiny.Crawler.Service.Interfaces;

namespace StarWarsDestiny.Crawler.Service.Impl
{
    public class SiteService : ReadWriteService<Site, CrawlerContext>, ISiteService
    {
        public SiteService(IReadWriteRepository<Site, CrawlerContext> repository) : base(repository)
        {
        }
    }
}
