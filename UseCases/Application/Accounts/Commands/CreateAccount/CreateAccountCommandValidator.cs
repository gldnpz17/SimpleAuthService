using Application.Common.Configuration;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Commands.CreateAccount
{
    internal class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator(
            ApplicationConfiguration configuration)
        {
            RuleFor(v => v.Username)
                .MaximumLength(configuration.MaxUsernameLength)
                .NotEmpty()
                .NotNull();

            RuleFor(v => v.Password)
                .MinimumLength(configuration.MinPasswordLength)
                .MaximumLength(configuration.MaxPasswordLength);
        }
    }
}
