using StarWarsDestiny.Common.Service.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWarsDestiny.Service.Interfaces
{
    public interface IPlayerRoundService : IReadWriteService<PlayerRound, StarWarsDestinyContext>
    {
        Task AddSuportAsync(int playerId, Card suport);
        Task AddLimboAsync(int playerId, Card card);
        Task ActivateCardAsync(int playerId, Card card);
        Task ResolveDieAsync(int playerId, PlayerRoundRolledDice rolledDice);
        Task DiscardToRerollAsync(int playerId, IList<PlayerRoundRolledDice> dice);
        Task UseCardActionAsync(int playerId, Card card, Effect effect);
        Task ClaimBattleFieldAsync(int playerId, Round round);
        Task PassAsync(int playerId, Round round);
    }
}
