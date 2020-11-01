using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Emails.Commands.AddEmailAddress
{
    internal class AddEmailAddressCommandValidator : AbstractValidator<AddEmailAddressCommand>
    {
        public AddEmailAddressCommandValidator()
        {
            RuleFor(v => v.EmailAddress)
                .EmailAddress();
        }
    }
}
