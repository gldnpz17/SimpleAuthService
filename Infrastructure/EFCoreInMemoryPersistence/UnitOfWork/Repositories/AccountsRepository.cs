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
    class AccountsRepository : IAccountRepository
    {
        private readonly AppDbContext _dbContext;

        internal AccountsRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Account entity)
        {
            _dbContext.Accounts.Add(entity);
        }

        public async Task DeleteAsync(Account entity)
        {
            _dbContext.Accounts.Remove(entity);
        }

        public async Task<IList<Account>> ReadAllAsync()
        {
            return _dbContext.Accounts.ToList();
        }

        public async Task<Account> ReadByIdAsync(Guid id)
        {
            return _dbContext.Accounts.First(account => account.Id == id);
        }

        public async Task<Account> ReadByUsernameAsync(string username)
        {
            return _dbContext.Accounts.First(account => account.Username == username);
        }
    }
}
