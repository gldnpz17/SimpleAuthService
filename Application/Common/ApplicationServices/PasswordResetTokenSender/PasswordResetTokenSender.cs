using Application.Common.External.EmailSender;
using Domain.Entities;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.ApplicationServices.PasswordResetTokenSender
{
    internal class PasswordResetTokenSender : IPasswordResetTokenSenderService
    {
        private readonly IEmailSender _emailSender;

        public PasswordResetTokenSender(
            IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public void SendResetToken(AccountEmailAddress primaryEmail, PasswordResetToken token)
        {
            _emailSender.SendEmail(
                new Email()
                {
                    Recipient = primaryEmail.EmailAddress,
                    Subject = "Password Reset",
                    EmailBodyType = EmailBodyType.HTML,
                    Body = $"your token : {token.ResetToken}"
                });
        }
    }
}
