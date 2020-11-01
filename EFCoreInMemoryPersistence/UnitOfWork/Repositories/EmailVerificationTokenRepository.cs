using ApplicationDependencies.UnitOfWork.Repositories;
using Domain.Entities;
using EFCoreInMemoryPersistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreInMemoryPersistence.UnitOfWork.Repositories
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
            var output = _appDbContext.EmailVerificationTokens.First(i => i.VerificationToken == verificationToken);
            return Task.FromResult(output);
        }
    }
}
