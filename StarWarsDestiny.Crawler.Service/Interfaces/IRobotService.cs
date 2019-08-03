using StarWarsDestiny.Common.Service.Interfaces;
using StarWarsDestiny.Crawler.Model;
using StarWarsDestiny.Crawler.Model.Enum;
using StarWarsDestiny.Crawler.Repository.Context;
using System.Threading.Tasks;

namespace StarWarsDestiny.Crawler.Service.Interfaces
{
    public interface IRobotService : IReadWriteService<Robot, CrawlerContext>
    {
        Task<Robot> GetRobotBySiteAndType(EnumSite site, EnumRobotType robotType);
    }
}
