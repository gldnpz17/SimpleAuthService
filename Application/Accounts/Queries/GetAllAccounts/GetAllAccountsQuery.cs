using Application.Accounts.Queries.DTOs.GetAccountById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Accounts.Queries.GetAllAccounts
{
    public class GetAllAccountsQuery : IRequest<List<AccountDto>>
    {

    }
}
