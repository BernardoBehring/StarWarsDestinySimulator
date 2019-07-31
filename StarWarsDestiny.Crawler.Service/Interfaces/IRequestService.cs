using StarWarsDestiny.CrawlerModel;

namespace StarWarsDestiny.Crawler.Service.Interfaces
{
    public interface IRequestService
    {
        long GetNext(Robot robo, Site site, Status status);
    }
}
