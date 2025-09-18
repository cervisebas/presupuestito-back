using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {

        private readonly ApplicationDbContext context;

        public MaterialRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<Material> Insert(Material material)
        {
            var result = await context.Materials.AddAsync(material);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public override async Task<bool> Update(Material material)
        {
            context.Materials.Update(material);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<Material?> GetById(int id)
        {
            return await context.Materials
                                          .Where(material => material.Status == true && material.MaterialId == id)
                                          .Include(material => material.OSubcategoryMaterial)
                                          .ThenInclude(subCategory => subCategory.OCategory)
                                          .FirstOrDefaultAsync();
        }

        public override async Task<List<Material>> GetAll(Expression<Func<Material, bool>>? filter = null)
        {
            return await context.Materials
                                          .Where(material => material.Status == true)
                                          .Include(material => material.OSubcategoryMaterial)
                                          .ThenInclude(subCategory => subCategory.OCategory)
                                          .ToListAsync();
        }

        public async Task<InvoiceItem?> GetMaterialPrice(int MaterialId)
        {          
            return await context.InvoiceItems
                                             .Where(material => material.MaterialId == MaterialId)
                                             .Include(material => material.OMaterial)
                                             .OrderByDescending(invoiceItem => invoiceItem.OInvoice.Date)
                                             .FirstOrDefaultAsync();
        }

    }
}
