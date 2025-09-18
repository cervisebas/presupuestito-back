using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class EmployeeHistoryRepository : Repository<EmployeeHistory>, IEmployeeHistoryRepository
    {

        private readonly ApplicationDbContext context;

        public EmployeeHistoryRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<EmployeeHistory> Insert(EmployeeHistory employeeHistory)
        {
            var result = await context.EmployeeHistories.AddAsync(employeeHistory);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public override async Task<bool> Update(EmployeeHistory employeeHistory)
        {
            context.EmployeeHistories.Update(employeeHistory);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<EmployeeHistory?> GetById(int id)
        {
            return await context.EmployeeHistories.Include(o => o.OEmployee)
                .Where(o => o.Status == true && o.EmployeeHistoryId == id).FirstOrDefaultAsync();
        }

        public override async Task<List<EmployeeHistory>> GetAll(Expression<Func<EmployeeHistory, bool>>? filter = null)
        {
            return await context.EmployeeHistories.Include(e => e.OEmployee)
                .Where(o => o.Status == true)
                .ToListAsync();
        }

    }
}
