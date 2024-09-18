using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private HealthTrackerDBContext _repoContext;
        private IUserRepository _user;
        public IUserRepository User
        { 
            get
            {
                if(_user==null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
             } 
        }

        public RepositoryWrapper(HealthTrackerDBContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}