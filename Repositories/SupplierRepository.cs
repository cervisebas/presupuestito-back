using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {

        private readonly ApplicationDbContext context;

        public SupplierRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<bool> Update(Supplier supplier)
        {
            context.Suppliers.Update(supplier);
            await context.SaveChangesAsync();
            return true;
        }
        
        public override async Task<Supplier?> GetById(int id)
        {
            return await context.Suppliers
                                          .Where(supplier => supplier.Status == true && supplier.SupplierId == id)
                                          .Include(supplier => supplier.OPerson)
                                          .FirstOrDefaultAsync();
        }

        public override async Task<List<Supplier>> GetAll(Expression<Func<Supplier, bool>>? filter = null)
        {
            return await context.Suppliers.Where(supplier => supplier.Status == true)
                                          .Include(supplier => supplier.OPerson) 
                                          .ToListAsync();
        }

    }
}
