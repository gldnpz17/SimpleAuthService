using ApplicationDependencies.UnitOfWork;
using ApplicationDependencies.UnitOfWork.Repositories;
using Domain.Entities;
using EFCorePostgresPersistence.Helpers.RepositoryBase;
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
        private readonly List<RepositoryBase> _repositories = new List<RepositoryBase>();

        public UnitOfWork()
        {
            _appDbContext = new AppDbContext();

            var accounts = new AccountsRepository(_appDbContext);
            _repositories.Add(accounts);
            Accounts = accounts;

            var emailVerificationTokens = new EmailVerificationTokenRepository(_appDbContext);
            _repositories.Add(emailVerificationTokens);
            EmailVerificationTokens = emailVerificationTokens;

            var authTokens = new AuthTokenRepository(_appDbContext);
            _repositories.Add(authTokens);
            AuthTokens = authTokens;
        }

        public IAccountRepository Accounts { get; private set; }

        public IEmailVerificationTokenRepository EmailVerificationTokens { get; private set; }

        public IAuthTokenRepository AuthTokens { get; private set; }

        public async Task SaveChangesAsync()
        {
            for (int x = 0; x < _repositories.Count; x++)
            {
                await _repositories[x].SaveChangesAsync();
            }
        }
    }
}
