using System.Collections.Generic;
using StarWarsDestiny.Common.Service.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using System.Threading.Tasks;
using StarWarsDestiny.Model.Dto;

namespace StarWarsDestiny.Service.Interfaces
{
    public interface ICardService : IReadWriteService<Card, StarWarsDestinyContext>
    {
        Task<bool> GetCardInDb(Card card);
        Task<Card> AddAsync(Card card);
        Task<Card> GetCardByDataCode(string dataCode);
        Task<IEnumerable<Card>> GetAllWithCardFilter(CardFilter filter, params string[] include);
    }
}
