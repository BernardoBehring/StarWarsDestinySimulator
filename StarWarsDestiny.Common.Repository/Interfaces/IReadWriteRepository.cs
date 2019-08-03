using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Common.Repository.Interfaces
{
    public interface IReadWriteRepository<T, TDbContext> : IReadRepository<T, TDbContext> where T : EntityId where TDbContext : DbContext
    {
        Task<T> CreateAsync(T model);
        Task<IEnumerable<T>> CreateAsync(IEnumerable<T> models);
        Task DeleteAsync(EntityId id);
        Task<T> PartialUpdateAsync(T model, string[] properties);
        Task<T> UpdateAsync(T model);
    }
}
