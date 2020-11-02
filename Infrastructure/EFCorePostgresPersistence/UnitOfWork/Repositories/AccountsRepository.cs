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
    internal class AccountsRepository : RepositoryBase, IAccountRepository
    {
        private List<Account> _created = new List<Account>();
        private List<Account> _removed = new List<Account>();

        public AccountsRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public async Task CreateAsync(Account entity)
        {
            _created.Add(entity);
        }

        public async Task DeleteAsync(Account entity)
        {
            _removed.Add(entity);
        }

        public async Task<IList<Account>> ReadAllAsync()
        {
            return _appDbContext.Accounts.ToList();
        }

        public async Task<Account> ReadByIdAsync(Guid id)
        {
            return await _appDbContext.Accounts.FirstAsync(account => account.Id == id);
        }

        public async Task<Account> ReadByUsernameAsync(string username)
        {
            return await _appDbContext.Accounts.FirstAsync(account => account.Username == username);
        }

        public override async Task SaveChangesAsync()
        {
            for (int x = 0; x < _created.Count; x++)
            {
                var account = _created[x];

                //save account first
                var tempEmail = account.PrimaryEmail;
                account.PrimaryEmail = null;

                _appDbContext.Accounts.Add(account);
                await _appDbContext.SaveChangesAsync();

                //then set primary email
                account.PrimaryEmail = tempEmail;

                await _appDbContext.SaveChangesAsync();
            }
            _created.Clear();

            for (int x = 0; x < _removed.Count; x++)
            {
                var account = _removed[x];

                //remove primary email first
                account.PrimaryEmail = null;
                
                await _appDbContext.SaveChangesAsync();

                //then remove account
                _appDbContext.Remove(account);

                await _appDbContext.SaveChangesAsync();
            }
            _removed.Clear();
        }
    }
}
