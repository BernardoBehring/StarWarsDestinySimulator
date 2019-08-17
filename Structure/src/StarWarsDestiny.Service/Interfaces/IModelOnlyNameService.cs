
using System.Threading.Tasks;

namespace StarWarsDestiny.Service.Interfaces
{
    public interface IModelOnlyNameService
    {
        Task<int> GetModelIdAsync(string name);
    }
}
