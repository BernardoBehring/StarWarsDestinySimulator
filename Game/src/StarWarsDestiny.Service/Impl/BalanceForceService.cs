using System.Linq;
using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Service.Impl;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using StarWarsDestiny.Service.Interfaces;
using System.Threading.Tasks;

namespace StarWarsDestiny.Service.Impl
{
    public class BalanceForceService : ReadWriteService<BalanceForce, StarWarsDestinyContext>, IBalanceForceService
    {
        private readonly IReadWriteRepository<BalanceForce, StarWarsDestinyContext> _repository;
        private readonly ICardLegalityService _cardLegalityService;

        public BalanceForceService(IReadWriteRepository<BalanceForce, StarWarsDestinyContext> repository,
            ICardLegalityService cardLegalityService) : base(repository)
        {
            _repository = repository;
            _cardLegalityService = cardLegalityService;
        }

        public async Task<BalanceForce> GetBalanceForceByCardLegality(int cardLegalityId)
        {
            var balanceForces = await _repository.GetAllWithParametersAsync(a => a.CardLegalityId == cardLegalityId);

            return balanceForces.FirstOrDefault();
        }
    }
}
