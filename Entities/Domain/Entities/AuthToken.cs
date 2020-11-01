using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class AuthToken
    {
        public string TokenString { get; set; }
        public Account Account { get; set; }
        public DateTime LastUsed { get; set; }
    }
}
