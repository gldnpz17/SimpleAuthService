using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Emails.Commands.RemoveEmailAddress
{
    internal class RemoveEmailAddressCommandValidator : AbstractValidator<RemoveEmailAddressCommand>
    {
        public RemoveEmailAddressCommandValidator()
        {
            RuleFor(v => v.EmailAddress)
                .EmailAddress();
        }
    }
}
