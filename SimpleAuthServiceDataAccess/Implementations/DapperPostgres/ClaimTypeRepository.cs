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
    public class ClaimTypeRepository : RepositoryBase, IClaimTypeRepository
    {
        public ClaimTypeRepository(GenericRepositoryConfig config) : base(config)
        {

        }

        public async Task CreateAsync(ClaimTypeEntity entity)
        {
            await _genericConfig.DbConnection.QueryAsync(SqlQueries.InsertClaimTypeSql,
                new
                {
                    ClaimTypeName = entity.ClaimName
                });
        }

        public async Task Delete(ClaimTypeEntity entity)
        {
            await _genericConfig.DbConnection.QueryAsync(SqlQueries.DeleteClaimTypeSql,
                new
                {
                    ClaimTypeName = entity.ClaimName
                });
        }

        public async Task<IEnumerable<ClaimTypeEntity>> ReadAllAsync()
        {
            return await _genericConfig.DbConnection.QueryAsync<ClaimTypeEntity>(SqlQueries.SelectAllClaimTypeSql);
        }

        public async Task<ClaimTypeEntity> ReadClaimTypeByClaimTypeName(string claimTypeName)
        {
            return (await _genericConfig.DbConnection.QueryAsync<ClaimTypeEntity>(SqlQueries.SelectClaimTypeByClaimTypeName,
                new
                {
                    ClaimTypeName = claimTypeName
                })).First();
        }
    }
}
