using StarWarsDestiny.Crawler.Base.Controller;
using StarWarsDestiny.Crawler.Model.Enum;
using StarWarsDestiny.Crawler.Service.Interfaces;
using System.Threading.Tasks;
using StarWarsDestiny.Common.Util.Extensions;
using StarWarsDestiny.Crawler.Card.Interfaces;

namespace StarWarsDestiny.Crawler.Card.Controller
{
    public class DownloadCardSWDestinyDBController : CrawlerBaseController, IDownloadCardSWDestinyDBController
    {
        private readonly IRobotService _robotService;
        private readonly ISiteService _siteService;

        public DownloadCardSWDestinyDBController(IRequestService requestService, IStatusService statusService,
            IRobotService robotService, ISiteService siteService,
            IDownloadCardSWDestinyDBExecutor executor) : base(requestService, statusService,
            robotService, siteService, executor)
        {
            _robotService = robotService;
            _siteService = siteService;
        }

        protected override async Task SetStartVariablesAsync()
        {
            Robot = await _robotService.GetRobotBySiteAndType(EnumSite.SWDestinyDB, EnumRobotType.CardDownload);
            Site = await _siteService.GetByIdAsync(((int) EnumSite.SWDestinyDB).ToEntityId());
        }
    }
}
