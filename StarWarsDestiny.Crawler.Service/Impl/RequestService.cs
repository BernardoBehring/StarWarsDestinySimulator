using System;
using System.Linq;
using System.Threading.Tasks;
using StarWarsDestiny.Common.Model;
using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Service.Impl;
using StarWarsDestiny.Crawler.Model;
using StarWarsDestiny.Crawler.Model.Enum;
using StarWarsDestiny.Crawler.Repository.Context;
using StarWarsDestiny.Crawler.Service.Interfaces;

namespace StarWarsDestiny.Crawler.Service.Impl
{
    public class RequestService : ReadWriteService<Request, CrawlerContext>, IRequestService
    {
        private readonly IReadWriteRepository<Request, CrawlerContext> _repository;

        public RequestService(IReadWriteRepository<Request, CrawlerContext> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<Request> GetNextAsync(Robot robot, Site site, Status status)
        {
            var robotId = robot.Id;
            var statusId = status.Id;
            var siteId = site.Id;

            var request = await _repository.GetAllWithParametersAsync(a =>
                a.RobotId == robotId && a.StatusId == statusId && a.Robot.SiteId == siteId, nameof(Request.Robot));
            
            return request.FirstOrDefault();
        }

        public async Task<Request> LogBeginRequestAsync(EntityId id)
        {
            var request = await _repository.GetByIdAsync(id);

            request.StartDateExecution = DateTime.Now;

            await _repository.PartialUpdateAsync(request, new[] {nameof(Request.StartDateExecution)});

            return request;
        }

        public async Task<Request> LogErrorWaitingAnalyzeAsync(EntityId id, string message)
        {
            var request = await _repository.GetByIdAsync(id);

            if(request.StartDateExecution != null)
                request.EndDateExecution = DateTime.Now;

            request.Response = message;
            request.StatusId = (int) EnumStatus.ErrorExecutionWaitingAnalysis;

            await _repository.PartialUpdateAsync(request,
                new[] {nameof(Request.StatusId), nameof(Request.Response), nameof(Request.EndDateExecution)});

            return request;
        }

        public async Task<Request> LogSuccessfullyConcludedAsync(EntityId id)
        {
            var request = await _repository.GetByIdAsync(id);

            request.StatusId = (int) EnumStatus.SuccessfullyConcluded;
            request.Response = "Successfully Concluded!";

            await _repository.PartialUpdateAsync(request, new[] {nameof(Request.StatusId), nameof(Request.Response)});

            return request;
        }

        public async Task<Request> LogTerminationExecutionAsync(EntityId id)
        {
            var request = await _repository.GetByIdAsync(id);

            request.EndDateExecution = DateTime.Now;

            await _repository.PartialUpdateAsync(request, new[] {nameof(Request.EndDateExecution)});
            return request;
        }
    }
}
