using SimpleAuthServiceDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuthServiceDataAccess.Repositories
{
    public interface IAuthTokenRepository : 
        IGenericCreateRepository<AuthTokenEntity>,
        IGenericReadAllRepository<AuthTokenEntity>,
        IGenericUpdateRepository<AuthTokenEntity>,
        IGenericDeleteRepository<AuthTokenEntity>
    {
        Task<AuthTokenEntity> ReadAuthTokenByTokenStringAsync(string TokenString);
        Task DeleteAuthTokenByTokenStringAsync(string tokenString);
    }
}
