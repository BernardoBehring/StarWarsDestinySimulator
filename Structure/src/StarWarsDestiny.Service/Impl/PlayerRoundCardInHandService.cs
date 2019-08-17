using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Service.Impl;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using StarWarsDestiny.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace StarWarsDestiny.Service.Impl
{
    public class PlayerRoundCardInHandService : ReadWriteService<PlayerRoundCardInHand, StarWarsDestinyContext>,
        IPlayerRoundCardInHandService
    {
        public PlayerRoundCardInHandService(
            IReadWriteRepository<PlayerRoundCardInHand, StarWarsDestinyContext> repository) : base(repository)
        {
        }

        public async Task RemoveCardFromHand(PlayerRoundCardInHand cardInHand)
        {
            cardInHand.DeletedIn = DateTime.Now;

            await PartialUpdateAsync(cardInHand, new[] { nameof(PlayerRoundCardInHand.DeletedIn) });
        }
    }
}
