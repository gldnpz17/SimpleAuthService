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
    class EmailVerificationTokenRepository : IEmailVerificationTokenRepository
    {
        private readonly AppDbContext _appDbContext;

        internal EmailVerificationTokenRepository(
            AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<EmailVerificationToken> ReadByVerificationTokenAsync(string verificationToken)
        {
            return await _appDbContext.EmailVerificationTokens.FirstAsync(i => i.VerificationToken == verificationToken);
        }
    }
}
