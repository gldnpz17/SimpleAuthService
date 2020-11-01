using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Authentication.Commands.Logout
{
    internal class LogoutCommandValidator : AbstractValidator<LogoutCommand>
    {
        public LogoutCommandValidator()
        {
            RuleFor(v => v.AuthToken)
                .NotEmpty();
        }
    }
}
