using ApplicationDependencies.UnitOfWork.Repositories;
using Domain.Entities;
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

        public Task<EmailVerificationToken> ReadByVerificationTokenAsync(string verificationToken)
        {
            return Task.FromResult(_appDbContext.EmailVerificationTokens.First(i => i.VerificationToken == verificationToken));
        }
    }
}
