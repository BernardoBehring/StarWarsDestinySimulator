﻿using StarWarsDestiny.Common.Service.Interfaces;
using StarWarsDestiny.Crawler.Model;
using StarWarsDestiny.Model;
using System.Threading.Tasks;

namespace StarWarsDestiny.Crawler.Service.Interfaces
{
    public interface IRequestService : IReadWriteService<Request, EntityId>
    {
        Task<Request> LogBeginRequestAsync(EntityId id);
        Task<Request> GetNextAsync(Robot robo, Site site, Status status);
        Task<Request> LogSuccessfullyConcludedAsync(EntityId id);
        Task<Request> LogErrorWaitingAnalyzeAsync(EntityId id, string message);
        Task<Request> LogTerminationExecutionAsync(EntityId id);
    }
}
