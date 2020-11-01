using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Claims.Queries.GetAllClaims
{
    internal class GetAllClaimsQueryValidator : AbstractValidator<GetAllClaimsQuery>
    {
        public GetAllClaimsQueryValidator()
        {
            RuleFor(v => v.AccountId)
                .NotEmpty();
        }
    }
}
