using System.Linq;
using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Service.Impl;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using StarWarsDestiny.Service.Interfaces;
using System.Threading.Tasks;

namespace StarWarsDestiny.Service.Impl
{
    public class CardLegalityService : ReadWriteService<CardLegality, StarWarsDestinyContext>, ICardLegalityService
    {
        private readonly IReadWriteRepository<CardLegality, StarWarsDestinyContext> _repository;

        public CardLegalityService(IReadWriteRepository<CardLegality, StarWarsDestinyContext> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<CardLegality> GetCardLegalityByCardLegality(int cardId, int legalityId)
        {
            var cardLegalities = await _repository.GetAllWithParametersAsync(a => a.CardId == cardId && a.LegalityId == legalityId);

            return cardLegalities.FirstOrDefault();
        }
    }
}
