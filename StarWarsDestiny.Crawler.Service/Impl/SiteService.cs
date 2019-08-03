using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Service.Impl;
using StarWarsDestiny.Crawler.Model;
using StarWarsDestiny.Crawler.Service.Interfaces;

namespace StarWarsDestiny.Crawler.Service.Impl
{
    public class SiteService : ReadWriteService<Site>, ISiteService
    {
        public SiteService(IReadWriteRepository<Site> repository) : base(repository)
        {
        }
    }
}
