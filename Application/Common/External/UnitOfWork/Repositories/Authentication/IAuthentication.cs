using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.External.UnitOfWork.Repositories.Authentication
{
    public interface IAuthentication
    {
        Task<Domain.Entities.Authentication> GetAuthenticationAsync();
    }
}
