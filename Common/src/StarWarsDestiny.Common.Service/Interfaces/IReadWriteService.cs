using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarWarsDestiny.Common.Model;

namespace StarWarsDestiny.Common.Service.Interfaces
{
    public interface IReadWriteService<T, TDbContext> : IReadService<T> where T : EntityId where TDbContext : DbContext
    {
        Task<T> CreateAsync(T model);
        Task<ICollection<T>> CreateAsync(ICollection<T> models);
        Task DeleteAsync(EntityId id);
        Task<T> PartialUpdateAsync(T model, string[] properties);
    }
}
