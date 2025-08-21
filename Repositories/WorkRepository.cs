using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class WorkRepository : Repository<Work>, IWorkRepository
    {

        private readonly ApplicationDbContext context;

        public WorkRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<bool> Insert(Work work)
        {
            await context.Works.AddAsync(work);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Update(Work work)
        {
            context.Works.Update(work);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<Work?> GetById(int id)
        {
            return await context.Works
                                      .Where(work => work.Status == true && work.WorkId == id)
                                      .Include(work => work.OMaterials.Where(material => material.Status == true))
                                      .ThenInclude(items => items.OMaterial)
                                        .ThenInclude(material => material.OSubcategoryMaterial)
                                            .ThenInclude(subCategory => subCategory.OCategory)
                                      .FirstOrDefaultAsync();
        }

        public override async Task<List<Work>> GetAll(Expression<Func<Work, bool>>? filter = null)
        {
            return await context.Works.Where(work => work.Status == true)
                                      .Include(work => work.OMaterials.Where(material => material.Status == true))
                                      .ThenInclude(items => items.OMaterial)
                                        .ThenInclude(material => material.OSubcategoryMaterial)
                                             .ThenInclude(subCategory => subCategory.OCategory)
                                      .ToListAsync();
        }

    }
}
