using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class EmailVerificationToken
    {
        public string VerificationToken { get; set; }
        public AccountEmailAddress EmailAddress { get; set; }
        public bool IsActive { get; set; }
    }
}
