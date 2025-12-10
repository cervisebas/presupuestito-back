using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepositories;

namespace PresupuestitoBack.Repositories.IRepository
{
    public interface ISettingRepository : IRepository<Setting>
    {
        Task<Setting?> GetByLabelAsync(string label);
        Task<Setting> UpdateOrCreateAsync(string label, string value);
    }
}
