using Application.Common.External.EmailSender;
using Domain.Entities;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.ApplicationServices.EmailVerification
{
    class EmailVerificationService : IEmailVerifierService
    {
        private readonly IEmailSender _emailSender;

        public EmailVerificationService(
            IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public void AttemptToVerify(AccountEmailAddress emailAddress, EmailVerificationToken token)
        {
            _emailSender.SendEmail(
                new Email()
                {
                    Recipient = emailAddress.EmailAddress,
                    Subject = "Email Address Verification",
                    EmailBodyType = EmailBodyType.HTML,
                    Body = $"your token : {token.VerificationToken}"
                });
        }
    }
}
