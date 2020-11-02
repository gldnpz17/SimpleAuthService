using ApplicationDependencies.UnitOfWork.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreInMemoryPersistence.UnitOfWork.Repositories
{
    public class AuthTokenRepository : IAuthTokenRepository
    {
        private readonly AppDbContext _appDbContext;

        internal AuthTokenRepository(
            AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<AuthToken> ReadAuthTokenByTokenStringAsync(string tokenString)
        {
            return _appDbContext.AuthTokens.First(authToken => authToken.TokenString == tokenString);
        }
    }
}
