using ApplicationDependencies.UnitOfWork.Repositories.Accounts;
using ApplicationDependencies.UnitOfWork.Repositories.Authentication;
using ApplicationDependencies.UnitOfWork.Repositories.EmailVerificationToken;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDependencies.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAccountRepository Accounts { get; }
        IAuthentication Authentication { get; }
        IEmailVerificationToken EmailVerificationToken { get; }
        Task SaveChangesAsync();
    }
}
