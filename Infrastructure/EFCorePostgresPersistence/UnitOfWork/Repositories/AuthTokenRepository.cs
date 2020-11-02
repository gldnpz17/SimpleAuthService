using ApplicationDependencies.UnitOfWork.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePostgresPersistence.UnitOfWork.Repositories
{
    public class AuthTokenRepository : IAuthTokenRepository
    {
        private readonly AppDbContext _dbContext;

        internal AuthTokenRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AuthToken> ReadAuthTokenByTokenStringAsync(string tokenString)
        {
            return await _dbContext.AuthTokens.FirstAsync(i => i.TokenString == tokenString);
        }
    }
}
