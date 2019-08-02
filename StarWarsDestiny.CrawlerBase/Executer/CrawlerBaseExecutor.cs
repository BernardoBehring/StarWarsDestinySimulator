using StarWarsDestiny.Crawler.Base.Interfaces;
using System.Net;

namespace StarWarsDestiny.Crawler.Base.Executer
{
    public class CrawlerBaseExecutor : ICrawlerBaseExecutor
    {
        public WebClient webClient { get; set; }
    }
}
