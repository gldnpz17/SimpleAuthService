using Dapper;
using SimpleAuthServiceDataAccess.Databases.DapperPostgres.Config;
using SimpleAuthServiceDataAccess.Databases.DapperPostgres.SQL;
using SimpleAuthServiceDataAccess.Entities;
using SimpleAuthServiceDataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuthServiceDataAccess.Databases.DapperPostgres
{
    public class AccountClaimRepository : RepositoryBase, IAccountClaimRepository
    {   
        public AccountClaimRepository(GenericRepositoryConfig config) : base(config)
        {

        }

        public async Task CreateAsync(AccountClaimEntity entity)
        {
            await _genericConfig.DbConnection.QueryAsync(SqlQueries.InsertAccountClaimSql,
                new
                {
                    AccountId = entity.AccountId,
                    ClaimTypeName = entity.ClaimTypeName,
                    Value = entity.Value
                });
        }

        public async Task Delete(AccountClaimEntity entity)
        {
            await _genericConfig.DbConnection.QueryAsync(SqlQueries.DeleteAccountClaimSql,
                new
                {
                    AccountId = entity.AccountId,
                    ClaimTypeName = entity.ClaimTypeName
                });
        }

        public async Task<IEnumerable<AccountClaimEntity>> ReadAllAsync()
        {
            return await _genericConfig.DbConnection.QueryAsync<AccountClaimEntity>(SqlQueries.SelectAllAccountClaimSql);
        }

        public async Task<AccountClaimEntity> ReadByAccountIdAndClaimNameAsync(Guid accountId, string claimName)
        {
            return (await _genericConfig.DbConnection.QueryAsync<AccountClaimEntity>(SqlQueries.SelectAccountClaimByAccountIdAndClaimTypeNameSql,
                new
                {
                    AccountId = accountId,
                    ClaimTypeName = claimName
                })).First();
        }

        public async Task<IEnumerable<AccountClaimEntity>> ReadByAccountIdAsync(Guid accountId)
        {
            return await _genericConfig.DbConnection.QueryAsync<AccountClaimEntity>(SqlQueries.SelectAccountClaimByAccountIdSql,
                new
                {
                    AccountId = accountId
                });
        }

        public async Task UpdateAsync(AccountClaimEntity entity)
        {
            await _genericConfig.DbConnection.QueryAsync(SqlQueries.UpdateAccountClaimSql,
                new
                {
                    AccountId = entity.AccountId,
                    ClaimTypeName = entity.ClaimTypeName,
                    Value = entity.Value
                });
        }
    }
}
