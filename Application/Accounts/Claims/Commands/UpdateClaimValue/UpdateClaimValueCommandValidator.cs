using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Claims.Commands.UpdateClaimValue
{
    internal class UpdateClaimValueCommandValidator : AbstractValidator<UpdateClaimValueCommand>
    {
        public UpdateClaimValueCommandValidator()
        {
            RuleFor(v => v.AccountId)
                .NotEmpty();

            RuleFor(v => v.ClaimName)
                .NotEmpty();
        }
    }
}
