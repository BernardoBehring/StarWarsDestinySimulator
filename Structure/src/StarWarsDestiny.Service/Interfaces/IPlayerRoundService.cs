using StarWarsDestiny.Common.Service.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWarsDestiny.Service.Interfaces
{
    public interface IPlayerRoundService : IReadWriteService<PlayerRound, StarWarsDestinyContext>
    {
        Task AddSuportAsync(PlayerRound playerRound, Card suport);
        Task AddLimboAsync(PlayerRound playerRound, Card card);
        Task ActivateCardAsync(PlayerRound playerRound, Card card);
        Task ResolveDieAsync(PlayerRound playerRound, PlayerRoundRolledDice rolledDice);
        Task DiscardToRerollAsync(PlayerRound playerRound, IList<PlayerRoundRolledDice> dice, Card card);
        Task UseCardActionAsync(PlayerRound playerRound, Card card, Effect effect);
        Task ClaimBattleFieldAsync(PlayerRound playerRound);
        Task PassAsync(PlayerRound playerRound);
    }
}
