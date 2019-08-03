using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Service.Impl;
using StarWarsDestiny.Model.Common;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsDestiny.Service.Impl
{
    public class ModelOnlyNameService<T> : ReadWriteService<T> where T : ModelOnlyName, new()
    {
        private readonly IReadWriteRepository<T> _repository;

        public ModelOnlyNameService(IReadWriteRepository<T> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<int> GetModelIdAsync(string name)
        {
            var modelId = await GetModelByNameAsync(name);
            if (modelId == -1)
            {
                modelId = await AddModelByName(name);
            }

            return modelId;
        }

        private async Task<int> GetModelByNameAsync(string name)
        {
            var model = await _repository.GetAllWithParametersAsync(a => a.Name == name);

            if (model == default)
                return -1;

            return model.FirstOrDefault().Id;
        }

        private async Task<int> AddModelByName(string name)
        {
            var model = new T
            {
                Name = name,
                InsertedIn = DateTime.Now
            };

            var modelCreated = await _repository.CreateAsync(model);

            return modelCreated.Id;
        }
    }
}
