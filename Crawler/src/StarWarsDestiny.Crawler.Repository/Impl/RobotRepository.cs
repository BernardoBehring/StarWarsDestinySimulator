using StarWarsDestiny.Common.Repository.Impl;
using StarWarsDestiny.Crawler.Model;
using StarWarsDestiny.Crawler.Repository.Context;
using StarWarsDestiny.Crawler.Repository.Interfaces;

namespace StarWarsDestiny.Crawler.Repository.Impl
{
    public class RobotRepository : ReadWriteRepository<Robot, CrawlerContext>, IRobotRepository
    {
        public RobotRepository(CrawlerContext context) : base(context)
        {
        }
    }
}
