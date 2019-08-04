using System.Linq;
using System.Threading.Tasks;
using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Service.Impl;
using StarWarsDestiny.Crawler.Model;
using StarWarsDestiny.Crawler.Model.Enum;
using StarWarsDestiny.Crawler.Repository.Context;
using StarWarsDestiny.Crawler.Service.Interfaces;

namespace StarWarsDestiny.Crawler.Service.Impl
{
    public class RobotService : ReadWriteService<Robot, CrawlerContext>, IRobotService
    {
        private readonly IReadWriteRepository<Robot, CrawlerContext> _repository;

        public RobotService(IReadWriteRepository<Robot, CrawlerContext> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<Robot> GetRobotBySiteAndType(EnumSite site, EnumRobotType robotType)
        {
            var robots = await _repository.GetAllWithParametersAsync(a =>
                a.SiteId == (int)site && a.RobotTypeId == (int)robotType);

            return robots.FirstOrDefault();
        }
    }
}
