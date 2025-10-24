using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class FixedCostRepository : Repository<FixedCost>, IFixedCostRepository
    {

        private readonly ApplicationDbContext context;

        public FixedCostRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<FixedCost> Insert(FixedCost fixedCost)
        {
            var result = await context.FixedCosts.AddAsync(fixedCost);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public override async Task<bool> Update(FixedCost fixedCost)
        {
            context.FixedCosts.Update(fixedCost);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<FixedCost?> GetById(int id)
        {
            return await context.FixedCosts.FirstOrDefaultAsync();
        }

        public override async Task<List<FixedCost>> GetAll(Expression<Func<FixedCost, bool>>? filter = null)
        {
            return await context.FixedCosts
                .Where(o => o.Status == true)
                .ToListAsync();
        }

    }
}
