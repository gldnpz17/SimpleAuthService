using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Queries.GetAllAccounts
{
    internal class GetAllAccountsQueryValidator : AbstractValidator<GetAllAccountsQuery>
    {
        public GetAllAccountsQueryValidator()
        {

        }
    }
}
