using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Service.Interfaces;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Common.Service.Impl
{
    public class ReadWriteService<T> : ReadService<T>, IReadWriteService<T>
        where T : EntityId
    {
        private readonly IReadWriteRepository<T> _repository;

        public ReadWriteService(IReadWriteRepository<T> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<T> CreateAsync(T model)
        {
            return await _repository.CreateAsync(model);
        }

        public async Task<IEnumerable<T>> CreateAsync(IEnumerable<T> models)
        {
            return await _repository.CreateAsync(models);
        }

        public async Task DeleteAsync(EntityId id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<T> PartialUpdateAsync(T model, string[] properties)
        {
            return await _repository.PartialUpdateAsync(model, properties);
        }
    }
}
