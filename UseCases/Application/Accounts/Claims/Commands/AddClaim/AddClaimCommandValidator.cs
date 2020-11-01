using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Claims.Commands.AddClaim
{
    internal class AddClaimCommandValidator : AbstractValidator<AddClaimCommand>
    {
        public AddClaimCommandValidator()
        {
            RuleFor(v => v.AccountId)
                .NotEmpty();
            RuleFor(v => v.ClaimName)
                .NotEmpty();
        }
    }
}
