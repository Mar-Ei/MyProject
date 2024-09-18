using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace DataAccess.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected HealthTrackerDBContext RepositoryContext { get; set; }
        public RepositoryBase(HealthTrackerDBContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        public IQueryable<T> FindAll() => RepositoryContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
                RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        public void Create(T entily) => RepositoryContext.Set<T>().Add(entily);
        public void Update(T entily) => RepositoryContext.Set<T>().Update(entily);
        public void Delete(T entily) => RepositoryContext.Set<T>().Remove(entily);

    }
}
