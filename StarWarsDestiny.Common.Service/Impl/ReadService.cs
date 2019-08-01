using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Service.Interfaces;

namespace StarWarsDestiny.Common.Service.Impl
{
    public class ReadService<T, TId> : IReadService<T, TId> where T : TId
    {
        private readonly IReadRepository<T, TId> _repository;

        public ReadService(IReadRepository<T, TId> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithParametersAsync(Func<T, bool> filter)
        {
            return await _repository.GetAllWithParametersAsync(filter);
        }

        public async Task<T> GetByIdAsync(TId id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
