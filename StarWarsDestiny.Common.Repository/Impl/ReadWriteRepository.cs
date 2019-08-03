using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Common.Repository.Impl
{
    public class ReadWriteRepository<T, TDbContext> : ReadRepository<T, TDbContext>, IReadWriteRepository<T>
        where T : EntityId where TDbContext : DbContext
    {
        private Repository<TDbContext> repository;
        public ReadWriteRepository(TDbContext context) : base(context)
        {
            repository = new Repository<TDbContext>(context);
        }

        public async Task<T> CreateAsync(T model)
        {
            await repository.AddAsync(model);
            return model;
        }

        public async Task<IEnumerable<T>> CreateAsync(IEnumerable<T> models)
        {
            await repository.AddRangeAsync(models);
            return models;
        }

        public async Task DeleteAsync(EntityId id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<T> UpdateAsync(T model)
        {
            await repository.UpdateAsync(model);
            return model;
        }

        public Task<T> PartialUpdateAsync(T model, string[] properties)
        {
            throw new System.NotImplementedException();
        }
    }
}
