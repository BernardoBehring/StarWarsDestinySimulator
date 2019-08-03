using System.Collections.Generic;
using System.Threading.Tasks;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Common.Repository.Interfaces
{
    public interface IReadWriteRepository<T> : IReadRepository<T> where T : EntityId
    {
        Task<T> CreateAsync(T model);
        Task<IEnumerable<T>> CreateAsync(IEnumerable<T> models);
        Task DeleteAsync(EntityId id);
        Task<T> PartialUpdateAsync(T model, string[] properties);
        Task<T> UpdateAsync(T model);
    }
}
