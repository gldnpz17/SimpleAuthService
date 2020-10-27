using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SimpleAuthServiceDataAccess.Databases.DapperPostgres.Config
{
    public class GenericRepositoryConfig
    {
        public IDbConnection DbConnection { get; set; }
    }
}
