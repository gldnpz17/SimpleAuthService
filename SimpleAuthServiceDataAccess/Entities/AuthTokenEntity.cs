using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleAuthServiceDataAccess.Entities
{
    public class AuthTokenEntity
    {
        public string TokenString { get; set; }
        public Guid AccountId { get; set; }
        public DateTime LastUsed { get; set; }
    }
}
