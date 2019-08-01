using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWarsDestiny.Common.Repository.Interfaces
{
    public interface IReadRepository<T, TId> where T : TId
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllWithParametersAsync(Func<T, bool> filter);
        Task<T> GetByIdAsync(TId id);
    }
}
