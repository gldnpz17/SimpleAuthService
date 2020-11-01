using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Emails.Commands.VerifyEmailAddress
{
    internal class VerifyEmailAddressCommandValidator : AbstractValidator<VerifyEmailAddressCommand>
    {
        public VerifyEmailAddressCommandValidator()
        {
            RuleFor(v => v.VerificationCode)
                .NotEmpty();
        }
    }
}
