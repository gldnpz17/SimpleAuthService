using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Emails.Queries.GetPrimaryEmailAddress
{
    internal class GetPrimaryEmailAddressValidator : AbstractValidator<GetPrimaryEmailAddressQuery>
    {
        public GetPrimaryEmailAddressValidator()
        {
            RuleFor(v => v.AccountId)
                .NotEmpty();
        }
    }
}
