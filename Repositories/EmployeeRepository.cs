using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {

        private readonly ApplicationDbContext context;

        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<Employee> Insert(Employee employee)
        {
            var result = await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public override async Task<bool> Update(Employee employee)
        {
            context.Employees.Update(employee);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<Employee?> GetById(int id)
        {
            return await context.Employees
                                          .Where(employee => employee.Status == true && employee.EmployeeId == id)
                                          .Include(employee => employee.OPerson)
                                          .FirstOrDefaultAsync();
        }

        public override async Task<List<Employee>> GetAll(Expression<Func<Employee, bool>>? filter = null)
        {
            return await context.Employees.Where(employee => employee.Status == true)
                                          .Include(employee => employee.OPerson) 
                                          .ToListAsync();
        }

    }
}
