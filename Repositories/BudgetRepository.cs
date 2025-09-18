using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class BudgetRepository : Repository<Budget>, IBudgetRepository
    {

        private readonly ApplicationDbContext context;

        public BudgetRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }


        public override async Task<bool> Update(Budget budget)
        {
            context.Budgets.Update(budget);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<Budget?> GetById(int id)
        {
            return await context.Budgets.Where(budget => budget.Status == true && budget.BudgetId == id)
                                        .Include(budget => budget.Oclient)
                                        .Include(budget => budget.Works.Where(work => work.Status == true))
                                            .ThenInclude(work => work.OMaterials.Where(material => material.Status == true))
                                            .ThenInclude(work => work.OMaterial)
                                                .ThenInclude(material => material.OSubcategoryMaterial)
                                                    .ThenInclude(subCategory => subCategory.OCategory)
                                        .OrderByDescending(budget => budget.DateCreated)
                                        .FirstOrDefaultAsync();
        }

        public override async Task<List<Budget>> GetAll(Expression<Func<Budget, bool>>? filter = null)
        {
            return await context.Budgets.Where(o => o.Status == true)
                                        .Include(budget => budget.Oclient)
                                        .Include(budget => budget.Works.Where(work => work.Status == true))
                                            .ThenInclude(work => work.OMaterials.Where(material => material.Status == true))
                                            .ThenInclude(work => work.OMaterial)
                                                .ThenInclude(material => material.OSubcategoryMaterial)
                                                    .ThenInclude(subCategory => subCategory.OCategory)
                                        .OrderByDescending(work => work.DateCreated)
                                        .ToListAsync();
        }

        public async Task<List<Budget>> GetBudgetsByClientId(int ClientId)
        {
            return await context.Budgets.Where(budget => budget.Status == true && budget.ClientId == ClientId)
                                        .Include(budget => budget.Oclient)
                                        .Include(budget => budget.Works.Where(work => work.Status == true))
                                            .ThenInclude(work => work.OMaterials.Where(material => material.Status == true))
                                            .ThenInclude(work => work.OMaterial)
                                                .ThenInclude(material => material.OSubcategoryMaterial)
                                                    .ThenInclude(subCategory => subCategory.OCategory)
                                        .OrderByDescending(work => work.DateCreated)
                                        .ToListAsync();
        }

    }
}


