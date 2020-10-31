using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDependencies.UnitOfWork.Repositories.Authentication
{
    public interface IAuthentication
    {
        Task<Domain.Entities.Authentication> GetAuthenticationAsync();
    }
}
