using Domain.Models;
using Domain.Interfaces;
using DataAccess.Repositories;
using DataAccess.Wrapper;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private MedicalContext _repoContext;
        private IUserRepository _user;

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }

        public RepositoryWrapper(MedicalContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public async Task SaveAsync() 
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
