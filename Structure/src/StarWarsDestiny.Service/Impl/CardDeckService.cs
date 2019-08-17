using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Service.Impl;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.Service.Impl
{
    public class CardDeckService : ReadWriteService<CardDeck, StarWarsDestinyContext>, ICardDeckService
    {
        public CardDeckService(IReadWriteRepository<CardDeck, StarWarsDestinyContext> repository) : base(repository)
        {
        }
    }
}
