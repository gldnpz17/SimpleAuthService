using SimpleAuthServiceDataAccess.Databases.DapperPostgres.Config;
using SimpleAuthServiceDataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleAuthServiceDataAccess.Databases.DapperPostgres
{
    public abstract class RepositoryBase
    {
        internal readonly GenericRepositoryConfig _genericConfig;

        public RepositoryBase(GenericRepositoryConfig genericConfig) 
        {
            _genericConfig = genericConfig;
        }
    }
}
