using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {

        private readonly ApplicationDbContext context;

        public ClientRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<bool> Update(Client client)
        {
            context.Clients.Update(client);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<Client?> GetById(int id)
        {
            return await context.Clients
                                        .Include(client => client.OPerson)
                                        .Where(client => client.Status == true && client.ClientId == id)
                                        .FirstOrDefaultAsync();
        }

        public override async Task<List<Client>> GetAll(Expression<Func<Client, bool>>? filter = null)
        {
            return await context.Clients
                                        .Include(client => client.OPerson) 
                                        .Where(client => client.Status == true)
                                        .ToListAsync();
        }

    }
}


