﻿using StarWarsDestiny.Common.Service.Interfaces;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Service.Interfaces
{
    public interface IFactionService : IReadWriteService<Faction>, IModelOnlyNameService
    {
    }
}