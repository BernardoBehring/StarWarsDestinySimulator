using StarWarsDestiny.Common.Repository.Impl;
using StarWarsDestiny.Crawler.Model;
using StarWarsDestiny.Crawler.Repository.Context;
using StarWarsDestiny.Crawler.Repository.Interfaces;

namespace StarWarsDestiny.Crawler.Repository.Impl
{
    public class SiteRepository : ReadWriteRepository<Site, CrawlerContext>, ISiteRepository
    {
        public SiteRepository(CrawlerContext context) : base(context)
        {
        }
    }
}
