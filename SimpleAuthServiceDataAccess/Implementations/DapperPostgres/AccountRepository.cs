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
    public class AccountRepository : RepositoryBase, IAccountRepository
    {
        public AccountRepository(GenericRepositoryConfig config) : base(config)
        {

        }

        public async Task CreateAsync(AccountEntity entity)
        {
            await _genericConfig.DbConnection.QueryAsync(SqlQueries.InsertAccountSql,
                new
                {
                    Username = entity.Username,
                    PasswordHash = entity.PasswordHash,
                    PasswordSalt = entity.PasswordSalt
                });
        }

        public async Task Delete(AccountEntity entity)
        {
            await _genericConfig.DbConnection.QueryAsync(SqlQueries.DeleteAccountSql,
                new
                {
                    AccountId = entity.Id
                });
        }

        public async Task<AccountEntity> ReadAccountByAccountIdAsync(Guid accountId)
        {
            return (await _genericConfig.DbConnection.QueryAsync<AccountEntity>(SqlQueries.SelectAccountByAccountIdSql,
                new
                {
                    AccountId = accountId
                })).First();
        }

        public async Task<AccountEntity> ReadAccountByUsernameAsync(string username)
        {
            return (await _genericConfig.DbConnection.QueryAsync<AccountEntity>(SqlQueries.SelectAccountByUsernameSql,
                new
                {
                    Username = username
                })).First();
        }

        public async Task<IEnumerable<AccountEntity>> ReadAllAsync()
        {
            return await _genericConfig.DbConnection.QueryAsync<AccountEntity>(SqlQueries.SelectAllAccountSql);
        }

        public async Task UpdateAsync(AccountEntity entity)
        {
            await _genericConfig.DbConnection.QueryAsync(SqlQueries.UpdateAccountSql,
                new
                {
                    AccountId = entity.Id,
                    Username = entity.Username,
                    PasswordHash = entity.PasswordHash,
                    PasswordSalt = entity.PasswordSalt
                });
        }
    }
}
