using System.Threading.Tasks;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Common.Service.Interfaces
{
    public interface IReadWriteService<T> : IReadService<T> where T : EntityId
    {
        Task<T> CreateAsync(T model);
        Task DeleteAsync(EntityId id);
        Task<T> PartialUpdateAsync(T model, string[] properties);
    }
}
