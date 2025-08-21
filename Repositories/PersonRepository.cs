﻿using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {

        private readonly ApplicationDbContext context;

        public PersonRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<bool> Insert(Person person)
        {
            await context.People.AddAsync(person);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Update(Person person)
        {
            context.People.Update(person);
            await context.SaveChangesAsync();
            return true;
        }

        public override async Task<Person?> GetById(int id)
        {
            return await context.People
                                     .Where(p => p.Status == true && p.PersonId == id)
                                     .FirstOrDefaultAsync();
        }

        public override async Task<List<Person>> GetAll(Expression<Func<Person, bool>>? filter = null)
        {
            return await base.GetAll(filter);
        }

        public async Task<Person?> GetById2()
        {
            return await context.People
                .Where(p => p.Status == true)
                .OrderByDescending(p => p.PersonId)  
                .FirstOrDefaultAsync();
        }


    }
}
