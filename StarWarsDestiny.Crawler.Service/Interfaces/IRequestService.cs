using StarWarsDestiny.Common.Service.Interfaces;
using StarWarsDestiny.Crawler.Model;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Crawler.Service.Interfaces
{
    public interface IRequestService : IReadWriteService<Request, EntityId>
    {
        Request LogBeginRequest(EntityId id);
        int GetNext(Robot robo, Site site, Status status);
    }
}
