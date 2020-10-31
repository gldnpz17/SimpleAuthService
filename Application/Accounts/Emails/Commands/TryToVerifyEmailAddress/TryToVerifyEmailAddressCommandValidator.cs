using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Emails.Commands.TryToVerifyEmailAddress
{
    internal class TryToVerifyEmailAddressCommandValidator : AbstractValidator<TryToVerifyEmailAddressCommand>
    {
        public TryToVerifyEmailAddressCommandValidator()
        {
            RuleFor(v => v.EmailAddress)
                .EmailAddress();
        }
    }
}
