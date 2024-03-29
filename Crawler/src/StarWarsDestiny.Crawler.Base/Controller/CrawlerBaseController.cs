﻿using StarWarsDestiny.Crawler.Service.Interfaces;
using StarWarsDestiny.Crawler.Model;
using StarWarsDestiny.Crawler.Model.Enum;
using System;
using System.Threading;
using System.Threading.Tasks;
using StarWarsDestiny.Common.Util;
using StarWarsDestiny.Crawler.Base.Interfaces;
using StarWarsDestiny.Common.Util.Extensions;

namespace StarWarsDestiny.Crawler.Base.Controller
{
    public class CrawlerBaseController : ICrawlerBaseController
    {
        public Site Site { get; set; }
        public Status Status { get; set; }
        public Robot Robot { get; set; }

        private readonly IRequestService _requestService;
        private readonly IStatusService _statusService;
        private readonly IRobotService _robotService;
        private readonly ISiteService _siteService;
        private readonly ICrawlerBaseExecutor _executor;
        
        public CrawlerBaseController(IRequestService requestService,
            IStatusService statusService, IRobotService robotService,
            ISiteService siteService, ICrawlerBaseExecutor executor)
        {
            _requestService = requestService;
            _statusService = statusService;
            _robotService = robotService;
            _siteService = siteService;
            _executor = executor;
        }
        
        public async Task<Request> GetNextAsync()
        {
            return await _requestService.GetNextAsync(Robot, Site, Status);
        }

        public void Wait()
        {
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("-------- Waiting 3 minutes ------");
            Thread.Sleep(TimeSpan.FromMinutes(3));
        }

        private async Task<Request> GetRequestAsync(EnumStatus status)
        {
            Status = await _statusService.GetByIdAsync(((int)status).ToEntityId());

            return await _requestService.GetNextAsync(Robot, Site, Status);
        }

        private async Task<Request> LogBeginRequestAsync(int requestId)
        {
            return await _requestService.LogBeginRequestAsync(requestId.ToEntityId());
        }

        private async Task LogSuccessfullyConcludedAsync(int requestId)
        {
            await _requestService.LogSuccessfullyConcludedAsync(requestId.ToEntityId());
        }

        private async Task LogErrorWaitingAnalyzeAsync(int requestId, Exception error)
        {
            var errorMessage = string.Empty;
            GetErrorMessage(error, ref errorMessage);

            await _requestService.LogErrorWaitingAnalyzeAsync(requestId.ToEntityId(), errorMessage.Trim());
        }

        private static string GetErrorMessage(Exception error, ref string errorMessage)
        {
            errorMessage = errorMessage + " " + error.Message;

            if (error.InnerException == null)
                return errorMessage;

            GetErrorMessage(error.InnerException, ref errorMessage);
            
            return errorMessage;
        }

        private async Task LogTerminationExecutionAsync(int requestId)
        {
            if(requestId > 0)
                await _requestService.LogTerminationExecutionAsync(requestId.ToEntityId());
        }

        protected virtual Task SetStartVariablesAsync()
        {
            return Task.Run(() => { return -1;});
        }

        public async Task ExecuteAsync(EnumStatus status)
        {
            await SetStartVariablesAsync();
            var requestId = -1;

            try
            {
                var request = await GetRequestAsync(status);
                if (request != default)
                {
                    requestId = request.Id;
                    await LogBeginRequestAsync(requestId);

                    await _executor.ExecuteAsync();

                    await LogSuccessfullyConcludedAsync(requestId);
                }
            }
            catch (Exception e)
            {
                await LogErrorWaitingAnalyzeAsync(requestId, e);
            }
            finally
            {
                await LogTerminationExecutionAsync(requestId);
            }
        }
    }
}
