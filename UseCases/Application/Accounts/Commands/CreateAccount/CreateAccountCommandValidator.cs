using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Commands.CreateAccount
{
    internal class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(v => v.Username)
                .MaximumLength(64)
                .NotEmpty()
                .NotNull();

            RuleFor(v => v.Password)
                .MinimumLength(8)
                .MaximumLength(256);
        }
    }
}
