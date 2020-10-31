using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IEmailVerifierService
    {
        void AttemptToVerify(AccountEmailAddress emailAddress, EmailVerificationToken token);
    }
}
