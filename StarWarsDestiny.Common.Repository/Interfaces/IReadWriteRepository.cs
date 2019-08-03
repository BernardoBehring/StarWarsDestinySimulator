using System.Threading.Tasks;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Common.Repository.Interfaces
{
    public interface IReadWriteRepository<T> : IReadRepository<T> where T : EntityId
    {
        Task<T> CreateAsync(T model);
        Task DeleteAsync(EntityId id);
        Task<T> PartialUpdateAsync(T model, string[] properties);
        Task<T> UpdateAsync(T model);
    }
}
