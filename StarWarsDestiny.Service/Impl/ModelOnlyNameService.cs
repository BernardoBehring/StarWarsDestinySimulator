using Microsoft.EntityFrameworkCore;
using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Service.Impl;
using StarWarsDestiny.Model.Common;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsDestiny.Service.Impl
{
    public class ModelOnlyNameService<T, TDbContext> : ReadWriteService<T, TDbContext> where T : ModelOnlyName, new() where TDbContext : DbContext
    {
        private readonly IReadWriteRepository<T, TDbContext> _repository;

        public ModelOnlyNameService(IReadWriteRepository<T, TDbContext> repository) : base(repository)
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
