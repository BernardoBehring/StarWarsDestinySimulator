using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StarWarsDestiny.Common.Repository.Impl
{
    public class Repository<TDbContext> where TDbContext : DbContext
    {
        private DbContext DbContext { get; set; }
        public Repository(TDbContext context)
        {
            DbContext = context;
        }

        public IQueryable<T> GetQueryable<T>() where T : class
        {
            var query = DbContext.Set<T>().AsNoTracking();
            return query;
        }

        public async Task AddAsync<T>(T model) where T : class
        {
            await DbContext.Set<T>().AddAsync(model);
            await DbContext.SaveChangesAsync();
        }
        
        public async Task UpdateAsync<T>(T model) where T : class
        {
            DbContext.Set<T>().Update(model);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T model) where T : class
        {
            if(model == default)
                return;

            DbContext.Set<T>().Remove(model);
            await DbContext.SaveChangesAsync();
        }

        public async Task AddRangeAsync<T>(IEnumerable<T> models) where T : class
        {
            await DbContext.Set<T>().AddRangeAsync(models);
            await DbContext.SaveChangesAsync();
        }
    }
}
