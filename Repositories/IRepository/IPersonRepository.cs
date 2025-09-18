using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepositories;

namespace PresupuestitoBack.Repositories.IRepository
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<Person> GetLastCreatedPerson();
    }
}
