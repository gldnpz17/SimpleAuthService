using SimpleAuthServiceDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuthServiceDataAccess.Repositories
{
    public interface IAccountRepository :
        IGenericCreateRepository<AccountEntity>,
        IGenericReadAllRepository<AccountEntity>,
        IGenericUpdateRepository<AccountEntity>,
        IGenericDeleteRepository<AccountEntity>
    {
        Task<AccountEntity> ReadAccountByAccountIdAsync(Guid accountId);
        Task<AccountEntity> ReadAccountByUsernameAsync(string username);
    }
}
