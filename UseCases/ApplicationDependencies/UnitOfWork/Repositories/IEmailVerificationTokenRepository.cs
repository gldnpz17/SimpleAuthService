using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDependencies.UnitOfWork.Repositories
{
    public interface IEmailVerificationTokenRepository
    {
        Task<EmailVerificationToken> ReadByVerificationTokenAsync(string verificationToken);
    }
}
