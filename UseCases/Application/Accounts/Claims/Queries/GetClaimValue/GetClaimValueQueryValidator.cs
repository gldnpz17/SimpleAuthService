using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Claims.Queries.GetClaimValue
{
    internal class GetClaimValueQueryValidator : AbstractValidator<GetClaimValueQuery>
    {
        public GetClaimValueQueryValidator()
        {
            RuleFor(v => v.AccountId)
                .NotEmpty();

            RuleFor(v => v.ClaimName)
                .NotEmpty();
        }
    }
}
