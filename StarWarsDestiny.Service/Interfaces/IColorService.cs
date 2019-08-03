﻿using StarWarsDestiny.Common.Service.Interfaces;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Service.Interfaces
{
    public interface IColorService : IReadWriteService<Color>, IModelOnlyNameService
    {
    }
}
