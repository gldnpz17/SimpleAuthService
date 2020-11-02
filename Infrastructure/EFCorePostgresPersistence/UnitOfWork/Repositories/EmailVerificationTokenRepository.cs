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
    internal class EmailVerificationTokenRepository : RepositoryBase, IEmailVerificationTokenRepository
    {
        public EmailVerificationTokenRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }

        public async Task<EmailVerificationToken> ReadByVerificationTokenAsync(string verificationToken)
        {
            return await _appDbContext.EmailVerificationTokens.FirstAsync(i => i.VerificationToken == verificationToken);
        }
    }
}
