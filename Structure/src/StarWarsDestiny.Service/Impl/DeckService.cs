using System.Linq;
using System.Threading.Tasks;
using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.Service.Impl
{
    public class DeckService : ModelOnlyNameService<Deck, StarWarsDestinyContext>, IDeckService
    {
        private readonly IReadWriteRepository<Deck, StarWarsDestinyContext> _repository;

        public DeckService(IReadWriteRepository<Deck, StarWarsDestinyContext> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<Deck> GetByNameAndUrl(string name, string url)
        {
            var query = await _repository.GetAllWithParametersAsync(a => a.Name == name && a.Url == url);
            return query.FirstOrDefault();
        }
    }
}
