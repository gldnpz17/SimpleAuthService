using Dapper;
using SimpleAuthServiceDataAccess.Databases.DapperPostgres.Config;
using SimpleAuthServiceDataAccess.Databases.DapperPostgres.SQL;
using SimpleAuthServiceDataAccess.Entities;
using SimpleAuthServiceDataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuthServiceDataAccess.Databases.DapperPostgres
{
    public class ClaimTagRepository : RepositoryBase, IClaimTagRepository
    {
        public ClaimTagRepository(GenericRepositoryConfig config) : base(config)
        {

        }

        public async Task CreateAsync(ClaimTagEntity entity)
        {
            await _genericConfig.DbConnection.QueryAsync(SqlQueries.InsertClaimTagSql,
                new
                {
                    ClaimTypeName = entity.ClaimTypeName,
                    ClaimTagName = entity.ClaimTagName
                });
        }

        public async Task Delete(ClaimTagEntity entity)
        {
            await _genericConfig.DbConnection.QueryAsync(SqlQueries.DeleteClaimTagSql,
                new
                {
                    ClaimTypeName = entity.ClaimTypeName,
                    ClaimTagName = entity.ClaimTagName
                });
        }

        public async Task<IEnumerable<ClaimTagEntity>> ReadAllAsync()
        {
            return await _genericConfig.DbConnection.QueryAsync<ClaimTagEntity>(SqlQueries.SelectAllClaimTagSql);
        }

        public Task<IEnumerable<ClaimTagEntity>> ReadByClaimNameAsync(string claimName)
        {
            throw new NotImplementedException();
        }

        public Task<ClaimTagEntity> ReadClaimTagByClaimNameAndClaimTagNameAsync(string claimName, string claimTagName)
        {
            throw new NotImplementedException();
        }
    }
}
