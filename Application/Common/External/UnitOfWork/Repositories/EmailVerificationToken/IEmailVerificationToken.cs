using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.External.UnitOfWork.Repositories.EmailVerificationToken
{
    public interface IEmailVerificationToken
    {
        Task<Domain.Entities.EmailVerificationToken> ReadByVerificationTokenAsync(string verificationToken);
    }
}
