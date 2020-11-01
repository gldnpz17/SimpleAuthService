﻿using ApplicationDependencies.UnitOfWork.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDependencies.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAccountRepository Accounts { get; }
        IAuthenticationRepository Authentication { get; }
        IEmailVerificationTokenRepository EmailVerificationToken { get; }
        Task SaveChangesAsync();
    }
}
