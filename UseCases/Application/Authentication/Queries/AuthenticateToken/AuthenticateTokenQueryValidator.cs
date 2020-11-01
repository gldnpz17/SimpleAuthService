using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Authentication.Queries.AuthenticateToken
{
    internal class AuthenticateTokenQueryValidator : AbstractValidator<AuthenticateTokenQuery>
    {
        public AuthenticateTokenQueryValidator()
        {
            RuleFor(v => v.AuthToken)
                .NotEmpty();
        }
    }
}
