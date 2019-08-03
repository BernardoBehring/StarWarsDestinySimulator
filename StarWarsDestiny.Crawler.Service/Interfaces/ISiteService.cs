using StarWarsDestiny.Common.Service.Interfaces;
using StarWarsDestiny.Crawler.Model;
using StarWarsDestiny.Crawler.Repository.Context;

namespace StarWarsDestiny.Crawler.Service.Interfaces
{
    public interface ISiteService : IReadWriteService<Site, CrawlerContext>
    {
    }
}
