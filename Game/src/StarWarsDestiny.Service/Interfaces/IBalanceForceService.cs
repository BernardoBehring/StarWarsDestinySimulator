using StarWarsDestiny.Common.Service.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using System.Threading.Tasks;

namespace StarWarsDestiny.Service.Interfaces
{
    public interface IBalanceForceService : IReadWriteService<BalanceForce, StarWarsDestinyContext>
    {
        Task<BalanceForce> GetBalanceForceByCardLegality(int cardLegalityId);
    }
}
