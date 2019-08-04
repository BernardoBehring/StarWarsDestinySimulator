using StarWarsDestiny.Common.Service.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using System.Threading.Tasks;

namespace StarWarsDestiny.Service.Interfaces
{
    public interface ICardService : IReadWriteService<Card, StarWarsDestinyContext>
    {
        Task<bool> GetCardInDb(Card card);
        Task<Card> AddAsync(Card card);
    }
}
