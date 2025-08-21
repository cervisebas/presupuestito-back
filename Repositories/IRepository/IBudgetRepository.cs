using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepositories;

namespace PresupuestitoBack.Repositories.IRepository
{
    public interface IBudgetRepository : IRepository<Budget>
    {
        Task<List<Budget>> GetBudgetsByClientId(int ClientId);
    }
}
