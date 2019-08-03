using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Service.Impl;
using StarWarsDestiny.Model;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.Service.Impl
{
    public class CardService : ReadWriteService<Card>, ICardService
    {
        public CardService(IReadWriteRepository<Card> repository) : base(repository)
        {
        }
    }
}
