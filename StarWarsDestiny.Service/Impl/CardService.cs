using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Service.Impl;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.Service.Impl
{
    public class CardService : ReadWriteService<Card, StarWarsDestinyContext>, ICardService
    {
        public CardService(IReadWriteRepository<Card, StarWarsDestinyContext> repository) : base(repository)
        {
        }
    }
}
