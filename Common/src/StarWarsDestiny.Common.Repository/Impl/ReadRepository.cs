using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarWarsDestiny.Common.Model;
using StarWarsDestiny.Common.Repository.Interfaces;

namespace StarWarsDestiny.Common.Repository.Impl
{
    public class ReadRepository<T, TDbContext> : IReadRepository<T, TDbContext> where T : EntityId where TDbContext : DbContext
    {
        private Repository<TDbContext> repository;
        public ReadRepository(TDbContext context)
        {
            repository = new Repository<TDbContext>(context);
        }

        public async Task<IEnumerable<T>> GetAllAsync(params string[] include)
        {
            var query = repository.GetQueryable<T>();

            if (include != null)
            {
                foreach (var inc in include)
                {
                    query = query.Include(inc);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithParametersAsync(Func<T, bool> filter, params string[] include)
        {
            var query = repository.GetQueryable<T>();

            if (include != null)
            {
                foreach (var inc in include)
                {
                    query = query.Include(inc);
                }
            }

            if(filter != null)
                return query.Where(filter);

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
