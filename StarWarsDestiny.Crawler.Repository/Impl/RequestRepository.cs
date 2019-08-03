using StarWarsDestiny.Common.Repository.Impl;
using StarWarsDestiny.Crawler.Model;
using StarWarsDestiny.Crawler.Repository.Context;
using StarWarsDestiny.Crawler.Repository.Interfaces;

namespace StarWarsDestiny.Crawler.Repository.Impl
{
    public class RequestRepository : ReadWriteRepository<Request, CrawlerContext>, IRequestRepository
    {
        public RequestRepository(CrawlerContext context) : base(context)
        {
        }
    }
}
