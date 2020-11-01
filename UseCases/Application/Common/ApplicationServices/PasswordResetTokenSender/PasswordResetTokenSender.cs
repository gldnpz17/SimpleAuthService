using ApplicationDependencies.EmailSender;
using Domain.Entities;
using Domain.Services;

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
