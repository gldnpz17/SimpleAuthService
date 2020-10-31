using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Commands.ChangeUsername
{
    internal class UpdateUsernameCommandValidator : AbstractValidator<UpdateUsernameCommand>
    {
        internal UpdateUsernameCommandValidator()
        {
            RuleFor(v => v.NewUsername)
                .MaximumLength(64)
                .NotNull()
                .NotEmpty();
        }
    }
}
