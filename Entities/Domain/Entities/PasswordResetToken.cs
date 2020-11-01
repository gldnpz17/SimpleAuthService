using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class PasswordResetToken
    {
        public string ResetToken { get; set; }
        public bool IsActive { get; set; }
    }
}
