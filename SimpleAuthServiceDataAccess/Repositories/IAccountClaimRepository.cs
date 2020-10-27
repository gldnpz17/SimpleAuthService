using SimpleAuthServiceDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuthServiceDataAccess.Repositories
{
    public interface IAccountClaimRepository :
        IGenericCreateRepository<AccountClaimEntity>,
        IGenericReadAllRepository<AccountClaimEntity>,
        IGenericUpdateRepository<AccountClaimEntity>,
        IGenericDeleteRepository<AccountClaimEntity>
    {
        Task<IEnumerable<AccountClaimEntity>> ReadByAccountIdAsync(Guid accountId);
        Task<AccountClaimEntity> ReadByAccountIdAndClaimNameAsync(Guid accountId, string claimName);
    }
}
