using StarWarsDestiny.Common.Service.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using System.Threading.Tasks;

namespace StarWarsDestiny.Service.Interfaces
{
    public interface IPlayerRoundCardInLimboService : IReadWriteService<PlayerRoundCardInLimbo, StarWarsDestinyContext>
    {
        Task<PlayerRoundCardInLimbo> AddLimboAsync(PlayerRound playerRound, Card card);
    }
}
