using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepositories;

namespace PresupuestitoBack.Repositories.IRepository
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        Task<List<Invoice>?> GetInvoicesBySupplierId(int SupplierId);
    }
}
