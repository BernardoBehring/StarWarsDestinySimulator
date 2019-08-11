using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.Service.Impl
{
    public class DeckService : ModelOnlyNameService<Deck, StarWarsDestinyContext>, IDeckService
    {
        public DeckService(IReadWriteRepository<Deck, StarWarsDestinyContext> repository) : base(repository)
        {
        }
    }
}
