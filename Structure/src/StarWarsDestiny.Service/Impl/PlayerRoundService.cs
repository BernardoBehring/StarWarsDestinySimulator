using System;
using System.Collections.Generic;
using System.Linq;
using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Service.Impl;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using StarWarsDestiny.Service.Interfaces;
using System.Threading.Tasks;

namespace StarWarsDestiny.Service.Impl
{
    public class PlayerRoundService : ReadWriteService<PlayerRound, StarWarsDestinyContext>, IPlayerRoundService
    {
        private readonly IReadWriteRepository<PlayerRound, StarWarsDestinyContext> _repository;
        private readonly IPlayerRoundCardInPlayService _playerRoundCardInPlayService;
        private readonly IPlayerRoundCardInHandService _playerRoundCardInHandService;
        private readonly IPlayerRoundCardInLimboService _playerRoundCardInLimboService;

        public PlayerRoundService(IReadWriteRepository<PlayerRound, StarWarsDestinyContext> repository,
            IPlayerRoundCardInPlayService playerRoundCardInPlayService, 
            IPlayerRoundCardInHandService playerRoundCardInHandService,
            IPlayerRoundCardInLimboService playerRoundCardInLimboService) : base(repository)
        {
            _repository = repository;
            _playerRoundCardInPlayService = playerRoundCardInPlayService;
            _playerRoundCardInHandService = playerRoundCardInHandService;
            _playerRoundCardInLimboService = playerRoundCardInLimboService;
        }

        public async Task AddSuportAsync(PlayerRound playerRound, Card suport)
        {
            var cardInPlay = new PlayerRoundCardInPlay
            {
                CardId = suport.Id,
                InsertedIn = DateTime.Now,
                Exausted = false,
                PlayerRoundId = playerRound.Id
            };

            await _playerRoundCardInPlayService.CreateAsync(cardInPlay);

            playerRound.CardsInPlay.Add(cardInPlay);

            await RemoveCardFromHand(playerRound, suport);
        }

        private async Task RemoveCardFromHand(PlayerRound playerRound, Card card)
        {
            var cardInHand = playerRound.CardsInHand.First(a => a.CardId == card.Id);

            await _playerRoundCardInHandService.RemoveCardFromHand(cardInHand);
        }

        public async Task AddLimboAsync(PlayerRound playerRound, Card card)
        {
            var cardInLimbo = await _playerRoundCardInLimboService.AddLimboAsync(playerRound, card);

            playerRound.Limbo.Add(cardInLimbo);

            await RemoveCardFromHand(playerRound, card);
        }

        public async Task ActivateCardAsync(PlayerRound playerRound, Card card)
        {
            var properties = new List<string>();

            var cardInPlay = playerRound.CardsInPlay.FirstOrDefault(a => a.Id == card.Id);

            await _playerRoundCardInPlayService.ActivateCardAsync(cardInPlay);
        }

        public async Task ResolveDieAsync(PlayerRound playerRound, PlayerRoundRolledDice rolledDice)
        {
            throw new NotImplementedException();
        }

        public async Task DiscardToRerollAsync(PlayerRound playerRound, IList<PlayerRoundRolledDice> dice, Card card)
        {
            throw new NotImplementedException();
        }

        public async Task UseCardActionAsync(PlayerRound playerRound, Card card, Effect effect)
        {
            throw new NotImplementedException();
        }

        public async Task ClaimBattleFieldAsync(PlayerRound playerRound)
        {
            throw new NotImplementedException();
        }

        public async Task PassAsync(PlayerRound playerRound)
        {
            throw new NotImplementedException();
        }
    }
}
