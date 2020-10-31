using Application.Common.External.UnitOfWork.Repositories.Accounts;
using Application.Common.External.UnitOfWork.Repositories.Authentication;
using Application.Common.External.UnitOfWork.Repositories.EmailVerificationToken;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.External.UnitOfWork
{
    internal interface IUnitOfWork
    {
        IAccountRepository Accounts { get; }
        IAuthentication Authentication { get; }
        IEmailVerificationToken EmailVerificationToken { get; }
        Task SaveChangesAsync();
    }
}
