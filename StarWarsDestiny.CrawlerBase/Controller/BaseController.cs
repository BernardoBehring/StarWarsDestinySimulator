using StarWarsDestiny.Crawler.Service.Interfaces;
using StarWarsDestiny.Crawler.Base.Executer;
using StarWarsDestiny.Crawler.Model;
using StarWarsDestiny.Crawler.Model.Enum;
using System;
using System.Threading;
using StarWarsDestiny.Model;
using System.Threading.Tasks;
using StarWarsDestiny.Common.Util;

namespace StarWarsDestiny.Crawler.Base.Controller
{
    public class BaseController
    {
        public Site Site { get; set; }
        public Status Status { get; set; }
        public Robot Robot { get; set; }
        public BaseExecutor BaseExecutor { get; set; }

        private readonly IRequestService _requestService;
        private readonly IStatusService _statusService;
        private readonly IRobotService _robotService;
        private readonly ISiteService _siteService;

        public BaseController(IRequestService requestService,
            IStatusService statusService, IRobotService robotService,
            ISiteService siteService)
        {
            _requestService = requestService;
            _statusService = statusService;
            _robotService = robotService;
            _siteService = siteService;
        }

        public int GetNext()
        {
            return _requestService.GetNext(Robot, Site, Status);
        }

        public void Wait()
        {
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("-------- Esperando 3 minutos ------");
            Thread.Sleep(TimeSpan.FromMinutes(3));
        }

        public async Task<int> GetRequestAsync(EnumStatus status)
        {
            int requestId = -1;

            Status = await _statusService.GetByIdAsync(((int)status).ToEntityId());

            requestId = _requestService.GetNext(Robot, Site, Status);

            return requestId;
        }

        public Request LogBeginRequest(long requestId)
        {
            return _requestService.LogBeginRequest(requestId);
        }

        public void LogaConcluidoComSucesso(Request request)
        {
            _requestService.LogSuccessfullyConcluded(request);
        }

        public void LogErrorWaitingAnalyze(Request request, Exception erro)
        {
            _requestService.LogErrorWaitingAnalyze(request, erro.Message);
        }

        public void LogTerminationExecution(Request request)
        {
            _requestService.LogTerminationExecution(request);
        }
    }
}
