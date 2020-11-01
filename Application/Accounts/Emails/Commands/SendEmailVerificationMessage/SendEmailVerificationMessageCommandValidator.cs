using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Emails.Commands.TryToVerifyEmailAddress
{
    internal class SendEmailVerificationMessageCommandValidator : AbstractValidator<SendEmailVerificationMessageCommand>
    {
        public SendEmailVerificationMessageCommandValidator()
        {
            RuleFor(v => v.EmailAddress)
                .EmailAddress();
        }
    }
}
