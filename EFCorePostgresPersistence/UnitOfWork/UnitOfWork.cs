using ApplicationDependencies.UnitOfWork;
using ApplicationDependencies.UnitOfWork.Repositories;
using EFCorePostgresPersistence.UnitOfWork.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePostgresPersistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public UnitOfWork()
        {
            _appDbContext = new AppDbContext();

            Accounts = new AccountsRepository(_appDbContext);
            Authentication = new AuthenticationRepository(_appDbContext);
            EmailVerificationToken = new EmailVerificationTokenRepository(_appDbContext);
        }

        public IAccountRepository Accounts { get; private set; }

        public IAuthenticationRepository Authentication { get; private set; }

        public IEmailVerificationTokenRepository EmailVerificationToken { get; private set; }

        public async Task SaveChangesAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
