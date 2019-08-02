using StarWarsDestiny.Common.Service.Interfaces;
using StarWarsDestiny.Crawler.Model;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Crawler.Service.Interfaces
{
    public interface ISiteService : IReadWriteService<Site, EntityId>
    {
    }
}
