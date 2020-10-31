using Application.Accounts.Queries.DTOs.GetAccountById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Queries.GetAccountById
{
    public class GetAccountByIdQuery : IRequest<AccountDto>
    {
        public Guid Id { get; set; }
    }
}
