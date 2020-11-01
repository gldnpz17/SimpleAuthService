using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Authentication.Queries.PasswordLogin
{
    internal class PasswordLoginQueryValidator : AbstractValidator<PasswordLoginQuery>
    {
        public PasswordLoginQueryValidator()
        {
            RuleFor(v => v.Username)
                .NotEmpty();

            RuleFor(v => v.Password)
                .NotEmpty();
        }
    }
}
