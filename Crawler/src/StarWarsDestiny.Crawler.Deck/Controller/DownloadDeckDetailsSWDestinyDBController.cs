using System.Threading.Tasks;
using StarWarsDestiny.Common.Util.Extensions;
using StarWarsDestiny.Crawler.Base.Controller;
using StarWarsDestiny.Crawler.Deck.Interfaces;
using StarWarsDestiny.Crawler.Model.Enum;
using StarWarsDestiny.Crawler.Service.Interfaces;

namespace StarWarsDestiny.Crawler.Deck.Controller
{
    public class DownloadDeckDetailsSWDestinyDBController : CrawlerBaseController, IDownloadDeckDetailsSWDestinyDBController
    {
        private readonly IRobotService _robotService;
        private readonly ISiteService _siteService;

        public DownloadDeckDetailsSWDestinyDBController(IRequestService requestService, IStatusService statusService,
            IRobotService robotService, ISiteService siteService,
            IDownloadDeckSWDestinyDBExecutor executor) : base(requestService, statusService,
            robotService, siteService, executor)
        {
            _robotService = robotService;
            _siteService = siteService;
        }

        protected override async Task SetStartVariablesAsync()
        {
            Robot = await _robotService.GetRobotBySiteAndType(EnumSite.SWDestinyDB, EnumRobotType.DeckDetailDownload);
            Site = await _siteService.GetByIdAsync(((int)EnumSite.SWDestinyDB).ToEntityId());
        }
    }
}
