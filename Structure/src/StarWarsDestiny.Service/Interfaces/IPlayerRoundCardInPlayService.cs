﻿using StarWarsDestiny.Common.Service.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;
using System.Threading.Tasks;

namespace StarWarsDestiny.Service.Interfaces
{
    public interface IPlayerRoundCardInPlayService : IReadWriteService<PlayerRoundCardInPlay, StarWarsDestinyContext>
    {
        Task ActivateCardAsync(PlayerRoundCardInPlay cardInPlay);
    }
}
