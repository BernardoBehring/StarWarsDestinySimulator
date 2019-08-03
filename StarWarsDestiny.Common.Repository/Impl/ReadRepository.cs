using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Common.Repository.Impl
{
    public class ReadRepository<T, TDbContext> : IReadRepository<T, TDbContext> where T : EntityId where TDbContext : DbContext
    {
        private Repository<TDbContext> repository;
        public ReadRepository(TDbContext context)
        {
            repository = new Repository<TDbContext>(context);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var query = repository.GetQueryable<T>();

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithParametersAsync(Func<T, bool> filter)
        {
            var query = repository.GetQueryable<T>();

            if(filter != null)
                query = query.Where(filter).AsQueryable();

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(EntityId id)
        {
            var query = repository.GetQueryable<T>();
            query = query.Where(a => a.Id == id.Id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
