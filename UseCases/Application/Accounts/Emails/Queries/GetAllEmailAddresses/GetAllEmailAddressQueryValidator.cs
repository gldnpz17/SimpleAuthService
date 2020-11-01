using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Application.Accounts.Emails.Queries.GetAllEmailAddresses
{
    internal class GetAllEmailAddressQueryValidator : AbstractValidator<GetAllEmailAddressesQuery>
    {
        public GetAllEmailAddressQueryValidator()
        {
            RuleFor(v => v.AccountId)
                .NotEmpty();
        }
    }
}
