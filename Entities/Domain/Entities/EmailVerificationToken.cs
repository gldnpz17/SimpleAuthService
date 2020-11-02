using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class EmailVerificationToken
    {
        public virtual string VerificationToken { get; set; }
        public virtual AccountEmailAddress EmailAddress { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
