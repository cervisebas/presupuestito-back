using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {

        private readonly ApplicationDbContext context;

        public InvoiceRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<Invoice> Insert(Invoice invoice)
        {
            var result = await context.Invoices.AddAsync(invoice);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public override async Task<bool> Update(Invoice invoice)
        {
            context.Invoices.Update(invoice);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<Invoice?> GetById(int id)
        {
            return await context.Invoices
                                        .Where(invoice => invoice.Status == true && invoice.InvoiceId == id)
                                        .Include(invoice => invoice.OSupplier)
                                        .Include(invoice => invoice.InvoiceItems.Where(item => item.Status == true))
                                            .ThenInclude(invoiceItem => invoiceItem.OMaterial)   
                                        .OrderByDescending(item => item.Date)
                                        .FirstOrDefaultAsync();
        }

        public override async Task<List<Invoice>> GetAll(Expression<Func<Invoice, bool>>? filter = null)
        {
            return await context.Invoices
                                        .Where(invoice => invoice.Status == true)
                                        .Include(invoice => invoice.OSupplier)
                                        .Include(invoice => invoice.InvoiceItems.Where(item => item.Status == true))
                                            .ThenInclude(invoiceItem => invoiceItem.OMaterial)
                                        .OrderByDescending(item => item.Date)
                                        .ToListAsync();
        }

        public async Task<List<Invoice>?> GetInvoicesBySupplierId(int SupplierId)
        {
            return await context.Invoices
                                        .Where(invoice => invoice.Status == true && invoice.SupplierId == SupplierId)
                                        .Include(invoice => invoice.OSupplier)
                                        .Include(invoice => invoice.InvoiceItems.Where(item => item.Status == true))
                                            .ThenInclude(invoiceItem => invoiceItem.OMaterial)
                                        .OrderByDescending(item => item.Date)
                                        .ToListAsync();
        }

    }
}
