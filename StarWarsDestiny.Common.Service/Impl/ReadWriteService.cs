using System.Threading.Tasks;
using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Service.Interfaces;

namespace StarWarsDestiny.Common.Service.Impl
{
    public class ReadWriteService<T, TId> : ReadService<T, TId>, IReadWriteService<T, TId> where T : TId
    {
        private readonly IReadWriteRepository<T, TId> _repository;

        public ReadWriteService(IReadWriteRepository<T, TId> repository) : base(repository)
        {
            _repository = repository;
        }
        public async Task<T> CreateAsync(T model)
        {
            return await _repository.CreateAsync(model);
        }

        public async Task<T> DeleteAsync(TId id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<T> PartialUpdateAsync(T model, string[] properties)
        {
            return await _repository.PartialUpdateAsync(model, properties);
        }
    }
}
