using System.Threading.Tasks;
using StarWarsDestiny.Common.Repository.Interfaces;

namespace StarWarsDestiny.Common.Repository.Impl
{
    public class ReadWriteRepository<T, TId> : ReadRepository<T, TId>, IReadWriteRepository<T, TId> where T : TId
    {
        public Task<T> CreateAsync(T model)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> DeleteAsync(TId id)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> PartialUpdateAsync(T model, string[] properties)
        {
            throw new System.NotImplementedException();
        }
    }
}
