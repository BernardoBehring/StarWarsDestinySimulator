using StarWarsDestiny.Common.Service.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using System.Threading.Tasks;

namespace StarWarsDestiny.Service.Interfaces
{
    public interface IPlayerRoundCardInHandService : IReadWriteService<PlayerRoundCardInHand, StarWarsDestinyContext>
    {
        Task RemoveCardFromHand(PlayerRoundCardInHand cardInHand);
    }
}
