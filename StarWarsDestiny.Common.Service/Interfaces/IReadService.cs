﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Common.Service.Interfaces
{
    public interface IReadService<T> where T : EntityId
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllWithParametersAsync(Func<T, bool> filter);
        Task<T> GetByIdAsync(EntityId id);
    }
}