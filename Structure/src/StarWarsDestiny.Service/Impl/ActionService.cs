using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Util.Extensions;
using StarWarsDestiny.Model;
using StarWarsDestiny.Model.Dto;
using StarWarsDestiny.Model.Enum;
using StarWarsDestiny.Repository.Context;
using StarWarsDestiny.Service.Interfaces;
using Action = StarWarsDestiny.Model.Action;

namespace StarWarsDestiny.Service.Impl
{
    public class ActionService : ModelOnlyNameService<Action, StarWarsDestinyContext>, IActionService
    {
        private readonly IGameService _gameService;
        private readonly ICardService _cardService;
        private readonly IPlayerRoundService _playerRoundService;

        public ActionService(IReadWriteRepository<Action, StarWarsDestinyContext> repository, 
            IGameService gameService, ICardService cardService, IPlayerRoundService playerRoundService) : base(repository)
        {
            _gameService = gameService;
            _cardService = cardService;
            _playerRoundService = playerRoundService;
        }

        public async Task<IEnumerable<EnumAction>> GetListPossibleActionsAsync(GameActionDto gameActionDto)
        {
            var gameDetails = await GetPlayerGameRoundAsync(gameActionDto);

            var list = new List<EnumAction>
            {
                EnumAction.Pass
            };

            if (gameDetails.Round.BattleFieldClaimed && gameDetails.Round.PlayerGameIdClaimedBattlefield == gameActionDto.PlayerId)
                return list;

            if (!gameDetails.Round.BattleFieldClaimed)
                list.Add(EnumAction.ClaimBattleField);

            if (gameDetails.Player.DicePool.Count() > 0)
                list.Add(EnumAction.ResolveDice);

            if (gameDetails.Player.CardsInHand.Count() > 0)
                list.Add(EnumAction.PlayCard);

            if (gameDetails.Player.CardsInHand.Count() > 0 && gameDetails.Player.DicePool.Count() > 0)
                list.Add(EnumAction.DiscardAndReroll);

            if (gameDetails.Player.CardsInPlay.Any(a => (a.Card.IsCharacter || a.Card.IsSuport) && !a.Exausted) ||
                gameDetails.Player.CardsInPlay.Any(a => (a.Card.IsCharacter || a.Card.IsSuport) && a.Upgrades.Any(b => b.CanBeExausted && !b.Exausted)))
                list.Add(EnumAction.ActivateCard);

            if (gameDetails.Player.CardsInPlay.Any(a =>
                a.Card.Effects.Any(b => b.EnumEffect == EnumEffect.Action ||
                                    b.EnumEffect == EnumEffect.PowerAction)))
                list.Add(EnumAction.UseCardAction);

            return list;
        }

        private async Task<(PlayerRound Player, Game Game, Round Round, Card Card)> GetPlayerGameRoundAsync(
            GameActionDto gameActionDto)
        {
            var game = await _gameService.GetByIdAsync(gameActionDto.GameId.ToEntityId());
            var roundGame = game.Rounds.Single(a => a.Id == gameActionDto.RoundId);
            var round = roundGame.Round;

            var player = roundGame.PlayerRounds.Single(a => a.PlayerGameId == gameActionDto.PlayerId);
            
            var card = gameActionDto.CardId == null
                ? null
                : await _cardService.GetByIdAsync(gameActionDto.CardId.Value.ToEntityId());
            return (player, game, round, card);
        }

        public async Task<EnumMessage> PlayCardFromHandAsync(GameActionDto gameActionDto)
        {
            var gameDetails = await GetPlayerGameRoundAsync(gameActionDto);

            var hand = gameDetails.Player.CardsInHand;

            var cardPlayed = hand.First(a => a.Id == gameDetails.Card.Id);

            if (cardPlayed == null)
                return EnumMessage.CardNotInHand;

            var types = cardPlayed.Card.CardTypes.Select(a => (EnumType)a.Type.Id).ToList();

            if (types.Contains(EnumType.Event) || types.Contains(EnumType.Upgrade))
                await _playerRoundService.AddLimboAsync(gameDetails.Player, cardPlayed.Card);

            if (types.Contains(EnumType.Support))
                await _playerRoundService.AddSuportAsync(gameDetails.Player, cardPlayed.Card);

            hand.Remove(cardPlayed);

            return EnumMessage.Success;
        }

        public async Task<EnumMessage> ActivateCardAsync(GameActionDto gameActionDto, int cardId)
        {
            var gameDetails = await GetPlayerGameRoundAsync(gameActionDto);

            if (!gameDetails.Player.CardsInPlay.Any(a => a.Id == cardId))
            {
                return EnumMessage.CardNotInPlay;
            }

            await _playerRoundService.ActivateCardAsync(gameDetails.Player, gameDetails.Card);

            return EnumMessage.Success;
        }

        public async Task<EnumMessage> ResolveDice(GameActionDto gameActionDto, IList<Die> dice)
        {
            var gameDetails = await GetPlayerGameRoundAsync(gameActionDto);
            var dicePool = gameDetails.Player.DicePool;

            var rolledDices = new List<PlayerRoundRolledDice>();
            if (GetRolledDice(dice, dicePool, ref rolledDices))
                return EnumMessage.DieNotInPool;

            foreach (var rolledDie in rolledDices)
            {
                await _playerRoundService.ResolveDieAsync(gameDetails.Player, rolledDie);
            }

            return EnumMessage.Success;
        }

        private bool GetRolledDice(IList<Die> dice, IList<PlayerRoundRolledDice> dicePool,
            ref List<PlayerRoundRolledDice> rolledDices)
        {
            var diceIds = dicePool.Select(a => a.Id);
            var resolvingDiceIds = dice.Select(a => a.Id);

            foreach (var r in resolvingDiceIds)
            {
                if (!diceIds.Contains(r))
                {
                    return true;
                }
            }

            rolledDices = dicePool.Where(a => resolvingDiceIds.Contains(a.Id)).ToList();
            return false;
        }

        public async Task<EnumMessage> DiscardCardToReroll(GameActionDto gameActionDto, IList<Die> dice)
        {
            var gameDetails = await GetPlayerGameRoundAsync(gameActionDto);

            if (gameDetails.Player.CardsInHand.Count == 0)
                return EnumMessage.NotEnoughCardsToDiscard;

            if (!gameDetails.Player.CardsInHand.Any(a => a.Id == gameActionDto.CardId))
                return EnumMessage.CardNotInHand;

            var dicePool = gameDetails.Player.DicePool;

            var rolledDices = new List<PlayerRoundRolledDice>();
            if (GetRolledDice(dice, dicePool, ref rolledDices))
                return EnumMessage.DieNotInPool;

            await _playerRoundService.DiscardToRerollAsync(gameDetails.Player, rolledDices);

            return EnumMessage.Success;
        }

        public async Task<EnumMessage> UseCardAction(GameActionDto gameActionDto, Effect effect)
        {
            var gameDetails = await GetPlayerGameRoundAsync(gameActionDto);

            if (!gameDetails.Card.Effects.Any(a => a.Id == effect.Id))
                return EnumMessage.EffectNotPresentInCard;

            await _playerRoundService.UseCardActionAsync(gameDetails.Player, gameDetails.Card, effect);

            return EnumMessage.Success;
        }

        public async Task<EnumMessage> ClaimBattleField(GameActionDto gameActionDto)
        {
            var gameDetails = await GetPlayerGameRoundAsync(gameActionDto);

            if (gameDetails.Round.BattleFieldClaimed)
                return EnumMessage.BattleFieldAlreadyClaimed;

            await _playerRoundService.ClaimBattleFieldAsync(gameDetails.Player);

            return EnumMessage.Success;
        }

        public async Task<EnumMessage> Pass(GameActionDto gameActionDto)
        {
            var gameDetails = await GetPlayerGameRoundAsync(gameActionDto);

            await _playerRoundService.PassAsync(gameDetails.Player);

            return EnumMessage.Success;
        }
    }
}
