using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDependencies.UnitOfWork.Repositories
{
    public interface IAuthTokenRepository
    {
        Task<AuthToken> ReadAuthTokenByTokenStringAsync(string tokenString);
    }
}
