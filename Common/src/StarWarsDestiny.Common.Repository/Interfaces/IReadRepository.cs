using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarWarsDestiny.Common.Model;

namespace StarWarsDestiny.Common.Repository.Interfaces
{
    public interface IReadRepository<T, TDbContext> where T : EntityId where TDbContext : DbContext
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllWithParametersAsync(Func<T, bool> filter, params string[] include);
        Task<T> GetByIdAsync(EntityId id);
    }
}
