using StarWarsDestiny.Common.Service.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using System.Threading.Tasks;

namespace StarWarsDestiny.Service.Interfaces
{
    public interface ICardLegalityService : IReadWriteService<CardLegality, StarWarsDestinyContext>
    {
        Task<CardLegality> GetCardLegalityByCardLegality(int cardId, int legalityId);
    }
}
