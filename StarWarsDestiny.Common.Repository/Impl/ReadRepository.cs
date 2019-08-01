using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StarWarsDestiny.Common.Repository.Interfaces;

namespace StarWarsDestiny.Common.Repository.Impl
{
    public class ReadRepository<T, TId> : IReadRepository<T, TId> where T : TId
    {
        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllWithParametersAsync(Func<T, bool> filter)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(TId id)
        {
            throw new NotImplementedException();
        }
    }
}
