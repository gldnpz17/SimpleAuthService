using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Commands.DeleteAccount
{
    internal class DeleteAccountCommandValidator : AbstractValidator<DeleteAccountCommand>
    {
        public DeleteAccountCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty();
        }
    }
}
