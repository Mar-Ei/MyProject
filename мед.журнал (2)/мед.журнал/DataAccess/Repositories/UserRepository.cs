using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Interfaces;
using DataAccess.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
  
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(MedicalContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<List<User>> FindAll()
        {
            return await RepositoryContext.Set<User>().AsNoTracking().ToListAsync();
        }

        public async Task<List<User>> FindByCondition(Expression<Func<User, bool>> expression)
        {
            return await RepositoryContext.Set<User>()
                .Where(expression)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task Create(User entity)
        {
            await RepositoryContext.Set<User>().AddAsync(entity);
        }

        public async Task Update(User entity)
        {
            RepositoryContext.Set<User>().Update(entity);
            await Task.CompletedTask; 
        }

        public async Task Delete(User entity)
        {
            RepositoryContext.Set<User>().Remove(entity);
            await Task.CompletedTask; 
        }
    }
}
