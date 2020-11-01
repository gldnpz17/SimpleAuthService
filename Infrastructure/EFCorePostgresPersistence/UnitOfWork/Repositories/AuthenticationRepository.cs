using ApplicationDependencies.UnitOfWork.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePostgresPersistence.UnitOfWork.Repositories
{
    class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly AppDbContext _dbContext;

        internal AuthenticationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Domain.Entities.Authentication> GetAuthenticationAsync()
        {
            throw new Exception();
        }
    }
}
