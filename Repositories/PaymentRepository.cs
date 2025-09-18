using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {

        private readonly ApplicationDbContext context;

        public PaymentRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<bool> Update(Payment payment)
        {
            context.Payments.Update(payment);
            await context.SaveChangesAsync();
            return true;
        }

 /*       public override async Task<Payment> GetById(Expression<Func<Payment, bool>>? filter = null, bool tracked = true)
        {
            return await base.GetById(filter, tracked);
        }

        public override async Task<List<Payment>> GetAll(Expression<Func<Payment, bool>>? filter = null)
        {
            return await base.GetAll(filter);
        }
 */
    }
}
