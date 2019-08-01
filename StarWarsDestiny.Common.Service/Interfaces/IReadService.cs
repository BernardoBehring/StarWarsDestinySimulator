using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWarsDestiny.Common.Service.Interfaces
{
    public interface IReadService<T, TId> where T : TId
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllWithParametersAsync(Func<T, bool> filter);
        Task<T> GetByIdAsync(TId id);
    }
}
