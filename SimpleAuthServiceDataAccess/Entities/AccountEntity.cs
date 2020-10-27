using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleAuthServiceDataAccess.Entities
{
    public class AccountEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}
