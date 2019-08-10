using StarWarsDestiny.Common.Service.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWarsDestiny.Service.Interfaces
{
    public interface IPlayerGameService : IReadWriteService<PlayerGame, StarWarsDestinyContext>
    {
        Task AddSuportAsync(int playerId, Suport suport);
        Task AddLimboAsync(int playerId, Card card);
        Task ActivateCardAsync(int playerId, Card card);
        Task ResolveDieAsync(int playerId, RolledDice rolledDice);
        Task DiscardToRerollAsync(int playerId, IList<RolledDice> dice);
        Task UseCardActionAsync(int playerId, Card card, Effect effect);
        Task ClaimBattleFieldAsync(int playerId, Round round);
        Task PassAsync(int playerId, Round round);
    }
}
