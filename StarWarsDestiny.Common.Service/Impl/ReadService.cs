using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Service.Interfaces;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Common.Service.Impl
{
    public class ReadService<T> : IReadService<T> where T : EntityId
    {
        private readonly IReadRepository<T> _repository;

        public ReadService(IReadRepository<T> repository)
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

        public async Task<T> GetByIdAsync(EntityId id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
