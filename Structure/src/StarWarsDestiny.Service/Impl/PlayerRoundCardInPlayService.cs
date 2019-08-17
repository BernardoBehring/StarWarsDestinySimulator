using System.Threading.Tasks;
using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Service.Impl;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.Service.Impl
{
    public class PlayerRoundCardInPlayService : ReadWriteService<PlayerRoundCardInPlay, StarWarsDestinyContext>, IPlayerRoundCardInPlayService
    {
        public PlayerRoundCardInPlayService(
            IReadWriteRepository<PlayerRoundCardInPlay, StarWarsDestinyContext> repository) : base(repository)
        {
        }

        public async Task ActivateCardAsync(PlayerRoundCardInPlay cardInPlay)
        {
            cardInPlay.Exausted = true;

            await PartialUpdateAsync(cardInPlay, new[] {nameof(PlayerRoundCardInPlay.Exausted)});
        }
    }
}
