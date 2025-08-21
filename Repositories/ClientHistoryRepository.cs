using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class ClientHistoryRepository : Repository<ClientHistory>, IClientHistoryRepository
    {

        private readonly ApplicationDbContext context;

        public ClientHistoryRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<bool> Insert(ClientHistory clientHistory)
        {
            await context.ClientHistories.AddAsync(clientHistory);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Update(ClientHistory clientHistory)
        {
            context.ClientHistories.Update(clientHistory);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<ClientHistory> GetById(int id)
        {
            var prueba = await context.ClientHistories
                .Include(clientHistories => clientHistories.Oclient)
                .Include(clientHistories => clientHistories.Budgets.Where(budgets => budgets.ClientId == 1))
                .ThenInclude(budgets => budgets.Works.Where(work => work.Status == true))
                .ThenInclude(work => work.OMaterials.Where(material => material.Status == true))
                .ThenInclude(work => work.OMaterial)
                .ThenInclude(material => material.OSubcategoryMaterial)
                .ThenInclude(subCategory => subCategory.OCategory)
                .Where(clientHistories => clientHistories.Status == true)
                .Where(o => o.Status == true && o.ClientId == id)
                .FirstAsync();
            return prueba;
        }

        public override async Task<List<ClientHistory>> GetAll(Expression<Func<ClientHistory, bool>>? filter = null)
        {
            return await context.ClientHistories
                .Include(clientHistories => clientHistories.Oclient) 
                .Include(clientHistories => clientHistories.Budgets)
                .ThenInclude(budgets => budgets.Works.Where(work => work.Status == true))
                .ThenInclude(work => work.OMaterials.Where(material => material.Status == true))
                .ThenInclude(work => work.OMaterial)
                .ThenInclude(material => material.OSubcategoryMaterial)
                .ThenInclude(subCategory => subCategory.OCategory)
                .Where(clientHistories => clientHistories.Status == true)
                .ToListAsync();
        }

    }
}
