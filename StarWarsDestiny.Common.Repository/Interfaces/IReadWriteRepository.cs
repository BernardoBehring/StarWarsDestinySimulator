using System.Threading.Tasks;

namespace StarWarsDestiny.Common.Repository.Interfaces
{
    public interface IReadWriteRepository<T, TId> : IReadRepository<T, TId> where T : TId
    {
        Task<T> CreateAsync(T model);
        Task<T> DeleteAsync(TId id);
        Task<T> PartialUpdateAsync(T model, string[] properties);
    }
}
