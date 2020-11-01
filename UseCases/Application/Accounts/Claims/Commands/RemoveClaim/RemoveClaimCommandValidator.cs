using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Claims.Commands.RemoveClaim
{
    internal class RemoveClaimCommandValidator : AbstractValidator<RemoveClaimCommand>
    {
        public RemoveClaimCommandValidator()
        {
            RuleFor(v => v.AccountId)
                .NotEmpty();

            RuleFor(v => v.ClaimName)
                .NotEmpty();
        }
    }
}
