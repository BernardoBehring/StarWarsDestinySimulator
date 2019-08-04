using System.Threading.Tasks;

namespace StarWarsDestiny.Crawler.Base.Interfaces
{
    public interface ICrawlerBaseExtractor
    {
        Task ProcessPageAsync(string page, object obj);
    }
}
