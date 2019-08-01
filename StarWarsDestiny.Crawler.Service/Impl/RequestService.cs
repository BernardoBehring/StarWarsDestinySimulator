using StarWarsDestiny.Common.Service.Impl;
using StarWarsDestiny.Crawler.Model;
using StarWarsDestiny.Crawler.Service.Interfaces;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Crawler.Service.Impl
{
    public class RequestService : ReadWriteService<Request, EntityId>, IRequestService
    {
        public int GetNext(Robot robo, Site site, Status status)
        {
            throw new System.NotImplementedException();
        }

        public Request LogBeginRequest(EntityId id)
        {
            throw new System.NotImplementedException();
        }
    }
}
