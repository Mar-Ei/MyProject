using DataAccess.Interfaces;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

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








