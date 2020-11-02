using ApplicationDependencies.UnitOfWork;
using ApplicationDependencies.UnitOfWork.Repositories;
using EFCoreInMemoryPersistence;
using EFCoreInMemoryPersistence.UnitOfWork.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreInMemoryPersistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public UnitOfWork()
        {
            _appDbContext = new AppDbContext();

            Accounts = new AccountsRepository(_appDbContext);
            EmailVerificationTokens = new EmailVerificationTokenRepository(_appDbContext);
            AuthTokens = new AuthTokenRepository(_appDbContext);
        }

        public IAccountRepository Accounts { get; private set; }

        public IEmailVerificationTokenRepository EmailVerificationTokens { get; private set; }
        
        public IAuthTokenRepository AuthTokens { get; private set; }

        public async Task SaveChangesAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
