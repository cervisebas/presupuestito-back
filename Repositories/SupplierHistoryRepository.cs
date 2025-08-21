using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class SupplierHistoryRepository : Repository<SupplierHistory>, ISupplierHistoryRepository
    {

        private readonly ApplicationDbContext context;

        public SupplierHistoryRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<bool> Insert(SupplierHistory supplierHistory)
        {
            await context.SupplierHistories.AddAsync(supplierHistory);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Update(SupplierHistory supplierHistory)
        {
            context.SupplierHistories.Update(supplierHistory);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<SupplierHistory> GetById(int id)
        {
            return await base.GetById(id);
        }

        public override async Task<List<SupplierHistory>> GetAll(Expression<Func<SupplierHistory, bool>>? filter = null)
        {
            return await context.SupplierHistories.Include(s => s.Osupplier) // Incluir la entidad Supplier
                .Where(o => o.Status == true)
                .ToListAsync();
        }

    }
}
