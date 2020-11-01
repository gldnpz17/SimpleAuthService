using Domain.Entities;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockDomainServices
{
    class MockEmailVerifierService : IEmailVerifierService
    {
        public void AttemptToVerify(AccountEmailAddress emailAddress, EmailVerificationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
