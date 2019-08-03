using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarWarsDestiny.Common.Model;

namespace StarWarsDestiny.Common.Repository.Impl
{
    public class Repository<TDbContext> where TDbContext : DbContext
    {
        private DbContext DbContext { get; set; }
        public Repository(TDbContext context)
        {
            DbContext = context;
        }

        public IQueryable<T> GetQueryable<T>() where T : EntityId
        {
            var query = DbContext.Set<T>().AsNoTracking();
            return query;
        }

        public async Task AddAsync<T>(T model) where T : EntityId
        {
            Detach<T>(model.Id);
            await DbContext.Set<T>().AddAsync(model);
            await DbContext.SaveChangesAsync();
        }
        
        public async Task UpdateAsync<T>(T model) where T : EntityId
        {
            Detach<T>(model.Id);
            DbContext.Set<T>().Update(model);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T model) where T : EntityId
        {
            if(model == default)
                return;
            Detach<T>(model.Id);
            DbContext.Set<T>().Remove(model);
            await DbContext.SaveChangesAsync();
        }

        public async Task AddRangeAsync<T>(IEnumerable<T> models) where T : EntityId
        {
            foreach (var model in models)
            {
                Detach<T>(model.Id);
            }
            await DbContext.Set<T>().AddRangeAsync(models);
            await DbContext.SaveChangesAsync();
        }

        private void Detach<T>(int id) where T : EntityId
        {
            var current = DbContext.Set<T>().Local.FirstOrDefault(a => a.Id == id);
            if (current != null)
                DbContext.Entry(current).State = EntityState.Detached;
        }
    }
}
