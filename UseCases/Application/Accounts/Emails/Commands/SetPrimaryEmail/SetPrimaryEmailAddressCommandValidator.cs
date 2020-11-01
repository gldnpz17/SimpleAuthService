using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Emails.Commands.SetPrimaryEmail
{
    internal class SetPrimaryEmailAddressCommandValidator : AbstractValidator<SetPrimaryEmailCommand>
    {
        public SetPrimaryEmailAddressCommandValidator()
        {
            RuleFor(v => v.AccountId)
                .NotEmpty();

            RuleFor(v => v.Email)
                .EmailAddress();
        }
    }
}
