using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Util;
using StarWarsDestiny.Model;
using StarWarsDestiny.Model.Enum;
using StarWarsDestiny.Repository.Context;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.Service.Impl
{
    public class ActionService : ModelOnlyNameService<Action, StarWarsDestinyContext>, IActionService
    {
        private readonly IGameService _gameService;

        public ActionService(IReadWriteRepository<Action, StarWarsDestinyContext> repository, IGameService gameService) : base(repository)
        {
            _gameService = gameService;
        }

        public async Task<IEnumerable<EnumAction>> GetListPossibleActionsAsync(int gameId, int playerId, int roundId)
        {
            var game = await _gameService.GetByIdAsync(gameId.ToEntityId());
            var player = game.Players.Single(a => a.PlayerId == playerId);
            var round = game.Rounds.Single(a => a.Id == roundId);

            var list = new List<EnumAction>
            {
                EnumAction.Pass
            };

            if (round.BattleFieldClaimed && round.PlayerIdClaimedBattlefield == playerId)
                return list;

            if (!round.BattleFieldClaimed)
                list.Add(EnumAction.ClaimBattleField);

            if (player.DicePool.Count() > 0)
                list.Add(EnumAction.ResolveDice);

            if (player.CardsInHand.Count() > 0)
                list.Add(EnumAction.PlayCard);

            if (player.CardsInHand.Count() > 0 && player.DicePool.Count() > 0)
                list.Add(EnumAction.DiscardAndReroll);

            if (player.Characters.Any(a => !a.Exausted) ||
                player.Characters.Any(a => a.Upgrades.Any(b => b.CanBeExausted && !b.Exausted)) ||
                player.Suports.Any(a => !a.Exausted) ||
                player.Suports.Any(a => a.Upgrades.Any(b => b.CanBeExausted && !b.Exausted)))
                list.Add(EnumAction.ActivateCard);

            if (player.CardsInPlay.Any(a => 
                a.Keywords.Any(b => b.EnumKeyWords == EnumKeyWords.Action || 
                                    b.EnumKeyWords == EnumKeyWords.PowerAction)))
                list.Add(EnumAction.UseCardAction);

            return list;
        }
    }
}
