using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Service.Impl;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using StarWarsDestiny.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace StarWarsDestiny.Service.Impl
{
    public class PlayerRoundCardInLimboService : ReadWriteService<PlayerRoundCardInLimbo, StarWarsDestinyContext>,
        IPlayerRoundCardInLimboService
    {
        public PlayerRoundCardInLimboService(
            IReadWriteRepository<PlayerRoundCardInLimbo, StarWarsDestinyContext> repository) : base(repository)
        {
        }

        public async Task<PlayerRoundCardInLimbo> AddLimboAsync(PlayerRound playerRound, Card card)
        {
            var cardInLimbo = new PlayerRoundCardInLimbo
            {
                CardId = card.Id,
                InsertedIn = DateTime.Now,
                PlayerRoundId = playerRound.Id
            };

            await CreateAsync(cardInLimbo);

            return cardInLimbo;
        }
    }
}
