using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class PasswordResetToken
    {
        public virtual string ResetToken { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
