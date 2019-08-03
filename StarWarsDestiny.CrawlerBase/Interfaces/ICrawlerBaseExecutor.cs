using System.Net;
using System.Threading.Tasks;

namespace StarWarsDestiny.Crawler.Base.Interfaces
{
    public interface ICrawlerBaseExecutor
    {
        WebClient webClient { get; set; }
        Task ExecuteAsync();
    }
}
