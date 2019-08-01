using System.Threading.Tasks;

namespace StarWarsDestiny.Common.Service.Interfaces
{
    public interface IReadWriteService<T, TId> : IReadService<T, TId> where T : TId
    {
        Task<T> CreateAsync(T model);
        Task<T> DeleteAsync(TId id);
        Task<T> PartialUpdateAsync(T model, string[] properties);
    }
}
