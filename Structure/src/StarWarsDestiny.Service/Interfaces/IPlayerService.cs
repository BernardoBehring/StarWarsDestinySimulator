﻿using StarWarsDestiny.Common.Service.Interfaces;
using StarWarsDestiny.Model;
using StarWarsDestiny.Repository.Context;

namespace StarWarsDestiny.Service.Interfaces
{
    public interface IPlayerService : IReadWriteService<Player, StarWarsDestinyContext>, IModelOnlyNameService
    {
    }
}
