using ApplicationDependencies.UnitOfWork.Repositories;
using Domain.Entities;
using EFCorePostgresPersistence.Helpers.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePostgresPersistence.UnitOfWork.Repositories
{
    internal class AuthTokenRepository : RepositoryBase, IAuthTokenRepository
    {
        public AuthTokenRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }

        public async Task<AuthToken> ReadAuthTokenByTokenStringAsync(string tokenString)
        {
            return await _appDbContext.AuthTokens.FirstAsync(i => i.TokenString == tokenString);
        }
    }
}
