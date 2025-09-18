using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {

        private readonly ApplicationDbContext context;

        public ItemRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<Item> Insert(Item item)
        {
            var result = await context.Items.AddAsync(item);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public override async Task<bool> Update(Item item)
        {
            context.Items.Update(item);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<Item?> GetById(int id)
        {
            return await context.Items
                                      .Where(item => item.Status == true && item.ItemId == id)
                                      .Include(item => item.OMaterial)
                                      .ThenInclude(material => material.OSubcategoryMaterial)
                                      .ThenInclude(SubCategory => SubCategory.OCategory)
                                      .FirstOrDefaultAsync();
        }

        public override async Task<List<Item>> GetAll(Expression<Func<Item, bool>>? filter = null)
        {
            return await context.Items
                                      .Where(item => item.Status == true)
                                      .Include(item => item.OMaterial)
                                      .ThenInclude(material => material.OSubcategoryMaterial)
                                      .ThenInclude(SubCategory => SubCategory.OCategory)
                                      .ToListAsync();
        }

    }
}
