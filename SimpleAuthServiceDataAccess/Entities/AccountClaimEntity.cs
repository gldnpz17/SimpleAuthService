using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleAuthServiceDataAccess.Entities
{
    public class AccountClaimEntity
    {
        public Guid AccountId { get; set; }
        public string ClaimTypeName { get; set; }
        public string Value { get; set; }
    }
}
