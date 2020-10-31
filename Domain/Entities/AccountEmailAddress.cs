using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AccountEmailAddress
    {
        public string EmailAddress { get; set; }
        public bool IsVerified { get; set; }
        public IList<EmailVerificationToken> VerificationTokens { get; set; }

        public void SendVerificationRequest(IEmailVerifierService emailVerifier, IAlphanumericTokenGenerator tokenGenerator)
        {
            if (!IsVerified)
            {
                //disable all previous verification tokens
                VerificationTokens.ToList().ForEach(i => i.IsActive = false);

                var newToken = new EmailVerificationToken()
                {
                    VerificationToken = tokenGenerator.GenerateAlphanumericToken(64),
                    IsActive = true,
                    EmailAddress = this
                };

                VerificationTokens.Add(newToken);

                emailVerifier.AttemptToVerify(this, newToken);
            }
        }

        public void VerifyEmail(EmailVerificationToken emailVerificationToken)
        {
            if (!IsVerified)
            {
                if (emailVerificationToken.IsActive)
                {
                    IsVerified = true;
                }
            }
        }
    }
}
