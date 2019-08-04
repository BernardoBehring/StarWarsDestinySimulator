using StarWarsDestiny.Crawler.Model.Enum;
using System.Threading.Tasks;

namespace StarWarsDestiny.Crawler.Base.Interfaces
{
    public interface ICrawlerBaseController
    {
        Task ExecuteAsync(EnumStatus status);
    }
}
