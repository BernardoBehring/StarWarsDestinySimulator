using StarWarsDestiny.Common.Service.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using System.Threading.Tasks;

namespace StarWarsDestiny.Service.Interfaces
{
    public interface IDeckService : IReadWriteService<Deck, StarWarsDestinyContext>, IModelOnlyNameService
    {
        Task<Deck> GetByNameAndUrl(string name, string url);
    }
}
