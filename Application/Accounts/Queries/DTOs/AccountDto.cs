using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Queries.DTOs.GetAccountById
{
    public class AccountDto
    {
        public Guid AccountId { get; set; }
        public string Username { get; set; }
    }
}
