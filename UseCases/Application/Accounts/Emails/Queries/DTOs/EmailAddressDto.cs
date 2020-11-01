using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Emails.Queries.DTOs
{
    public class EmailAddressDto
    {
        public string EmailAddress { get; set; }
        public bool IsVerified { get; set; }
    }
}
