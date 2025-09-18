using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class InvoiceItemRepository : Repository<InvoiceItem>, IInvoiceItemRepository
    {

        private readonly ApplicationDbContext context;

        public InvoiceItemRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<bool> Update(InvoiceItem invoiceItem)
        {
            context.InvoiceItems.Update(invoiceItem);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<InvoiceItem?> GetById(int id)
        {
            return await context.InvoiceItems
                                            .Include(InvoiceItem => InvoiceItem.OMaterial)
                                            .Where(InvoiceItem => InvoiceItem.Status == true && InvoiceItem.InvoiceItemId == id)
                                            .FirstOrDefaultAsync();
        }

        public override async Task<List<InvoiceItem>> GetAll(Expression<Func<InvoiceItem, bool>>? filter = null)
        {
            return await context.InvoiceItems.Include(c => c.OMaterial)
                .Where(o => o.Status == true)
                .ToListAsync();
        }

    }
}
