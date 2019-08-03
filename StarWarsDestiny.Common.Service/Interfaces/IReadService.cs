using StarWarsDestiny.Common.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWarsDestiny.Common.Service.Interfaces
{
    public interface IReadService<T> where T : EntityId
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(EntityId id);
    }
}
