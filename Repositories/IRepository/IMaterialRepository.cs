using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepositories;

namespace PresupuestitoBack.Repositories.IRepository
{
    public interface IMaterialRepository : IRepository<Material>
    {
        Task<InvoiceItem?> GetMaterialPrice(int MaterialId);
    }
}
