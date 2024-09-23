using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using DataAccess.Repositories;
using System.Linq.Expressions;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;



namespace DataAccess.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private MedicalContext repositoryContext;
        private MedicalContext repositoryContext1;

        protected MedicalContext RepositoryContext { get; set; }

       

       
        protected RepositoryBase(MedicalContext repositoryContext1)
        {
            this.repositoryContext1 = repositoryContext1;
        }

        // Asynchronous FindAll method
        public async Task<List<T>> FindAll() => await RepositoryContext.Set<T>().AsNoTracking().ToListAsync();

  
        public async Task<List<T>> FindByCondition(Expression<Func<T, bool>> expression) =>
            await RepositoryContext.Set<T>().Where(expression).AsNoTracking().ToListAsync();

        public async Task Create(T entity) => await RepositoryContext.Set<T>().AddAsync(entity);

      
        public Task Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
            return Task.CompletedTask; 
        }

   
        public Task Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
            return Task.CompletedTask;  
        }
    }
}