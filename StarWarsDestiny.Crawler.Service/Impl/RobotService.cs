using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Service.Impl;
using StarWarsDestiny.Crawler.Model;
using StarWarsDestiny.Crawler.Service.Interfaces;

namespace StarWarsDestiny.Crawler.Service.Impl
{
    public class RobotService : ReadWriteService<Robot>, IRobotService
    {
        public RobotService(IReadWriteRepository<Robot> repository) : base(repository)
        {
        }
    }
}
