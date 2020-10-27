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
    public class AuthTokenRepository : RepositoryBase, IAuthTokenRepository
    {
        public AuthTokenRepository(GenericRepositoryConfig config) : base(config)
        {
            
        }

        public async Task CreateAsync(AuthTokenEntity entity)
        {
            await _genericConfig.DbConnection.QueryAsync(SqlQueries.InsertAuthTokenSql,
                new
                {
                    TokenString = entity.TokenString,
                    AccountId = entity.AccountId
                });
        }

        public async Task Delete(AuthTokenEntity entity)
        {
            await DeleteAuthTokenByTokenStringAsync(entity.TokenString);
        }

        public async Task DeleteAuthTokenByTokenStringAsync(string tokenString)
        {
            await _genericConfig.DbConnection.QueryAsync(SqlQueries.DeleteAuthTokenSql,
                new
                {
                    TokenString = tokenString
                });
        }

        public async Task<IEnumerable<AuthTokenEntity>> ReadAllAsync()
        {
            return await _genericConfig.DbConnection.QueryAsync<AuthTokenEntity>(SqlQueries.SelectAllAuthTokenSql);
        }

        public async Task<AuthTokenEntity> ReadAuthTokenByTokenStringAsync(string TokenString)
        {
            return (await _genericConfig.DbConnection.QueryAsync<AuthTokenEntity>(SqlQueries.SelectAuthTokenByTokenStringSql,
                new
                {
                    TokenString = TokenString
                })).First();
        }

        public async Task UpdateAsync(AuthTokenEntity entity)
        {
            await _genericConfig.DbConnection.QueryAsync(SqlQueries.UpdateAuthTokenSql,
                new
                {
                    TokenString = entity.TokenString,
                    LastUsed = entity.LastUsed
                });
        }
    }
}
