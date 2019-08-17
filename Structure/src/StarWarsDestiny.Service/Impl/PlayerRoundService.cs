using System.Collections.Generic;
using System.Linq;
using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Service.Impl;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using StarWarsDestiny.Service.Interfaces;
using System.Threading.Tasks;
using StarWarsDestiny.Common.Util;

namespace StarWarsDestiny.Service.Impl
{
    public class PlayerRoundService : ReadWriteService<PlayerRound, StarWarsDestinyContext>, IPlayerRoundService
    {
        private readonly IReadWriteRepository<PlayerRound, StarWarsDestinyContext> _repository;

        public PlayerRoundService(IReadWriteRepository<PlayerRound, StarWarsDestinyContext> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task AddSuportAsync(int playerId, Card suport)
        {
            var player = await _repository.GetByIdAsync(playerId.ToEntityId());
            //player.CardsInPlay.Add(suport);

            await _repository.PartialUpdateAsync(player, new[] {nameof(PlayerRound.CardsInPlay) });
        }

        public async Task AddLimboAsync(int playerId, Card card)
        {
            var player = await _repository.GetByIdAsync(playerId.ToEntityId());
            //player.Limbo.Add(card);

            await _repository.PartialUpdateAsync(player, new[] { nameof(PlayerRound.Limbo) });
        }

        public async Task ActivateCardAsync(int playerId, Card card)
        {
            var player = await _repository.GetByIdAsync(playerId.ToEntityId());
            var properties = new List<string>();

            var cardInPlay = player.CardsInPlay.FirstOrDefault(a => a.Id == card.Id);

            if (card.IsCharacter)
            {
                //var character = player.Characters.FirstOrDefault(a => a.Id == card.Id);
                //character.Exausted = true;
                //((CharacterPlayerRound)cardInPlay).Exausted = true;
                //properties.Add(nameof(PlayerRound.Characters));
            }
            else if (card.IsSuport)
            {
                //var suport = player.Suports.FirstOrDefault(a => a.Id == card.Id);
                //suport.Exausted = true;
                //((Suport)cardInPlay).Exausted = true;
                //properties.Add(nameof(PlayerRound.Suports));
            }
            else if (card.IsUpgrade)
            {
                //var upgrades = player.Characters.SelectMany(a => a.Upgrades).ToList();
                //upgrades.AddRange(player.Suports.SelectMany(a => a.Upgrades));

                //var upgrade = upgrades.FirstOrDefault(a => a.Id == card.Id);

                //upgrade.Exausted = true;
                //((PlayerRoundCardInPlayUpgrade)cardInPlay).Exausted = true;
            }

            await _repository.PartialUpdateAsync(player, properties.ToArray());
        }

        public async Task ResolveDieAsync(int playerId, PlayerRoundRolledDice rolledDice)
        {
            var player = await _repository.GetByIdAsync(playerId.ToEntityId());
        }

        public async Task DiscardToRerollAsync(int playerId, IList<PlayerRoundRolledDice> dice)
        {
            var player = await _repository.GetByIdAsync(playerId.ToEntityId());
        }

        public async Task UseCardActionAsync(int playerId, Card card, Effect effect)
        {
            var player = await _repository.GetByIdAsync(playerId.ToEntityId());
        }

        public async Task ClaimBattleFieldAsync(int playerId, Round round)
        {
            var player = await _repository.GetByIdAsync(playerId.ToEntityId());

        }

        public async Task PassAsync(int playerId, Round round)
        {
            var player = await _repository.GetByIdAsync(playerId.ToEntityId());

        }
    }
}
