using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarWarsDestiny.Common.Model;
using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Service.Interfaces;

namespace StarWarsDestiny.Common.Service.Impl
{
    public class ReadService<T, TDbContext> : IReadService<T> where T : EntityId where TDbContext : DbContext
    {
        private readonly IReadRepository<T, TDbContext> _repository;

        public ReadService(IReadRepository<T, TDbContext> repository)
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
