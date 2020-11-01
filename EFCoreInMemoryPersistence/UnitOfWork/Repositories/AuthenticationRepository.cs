using ApplicationDependencies.UnitOfWork.Repositories;
using Domain.Entities;
using EFCoreInMemoryPersistence;
using EFCoreInMemoryPersistence.UnitOfWork.Helpers.DbSetListAdapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreInMemoryPersistence.UnitOfWork.Repositories
{
    class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly AppDbContext _dbContext;

        internal AuthenticationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Authentication> GetAuthenticationAsync()
        {
            return new Authentication(new DbSetCollectionAdapter<AuthToken>(_dbContext.AuthTokens), new DbSetCollectionAdapter<Account>(_dbContext.Accounts));
        }
    }
}
