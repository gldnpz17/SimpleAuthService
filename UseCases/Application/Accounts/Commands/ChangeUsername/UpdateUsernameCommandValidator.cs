using Application.Common.Configuration;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Commands.ChangeUsername
{
    internal class UpdateUsernameCommandValidator : AbstractValidator<UpdateUsernameCommand>
    {
        public UpdateUsernameCommandValidator(
            ApplicationConfiguration configuration)
        {
            RuleFor(v => v.NewUsername)
                .MaximumLength(configuration.MaxUsernameLength)
                .NotNull()
                .NotEmpty();
        }
    }
}
