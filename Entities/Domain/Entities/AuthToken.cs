using Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class AuthToken
    {
        public virtual string TokenString { get; set; }
        public virtual Account Account { get; set; }
        public virtual DateTime LastUsed { get; set; }

        public void DestroyToken()
        {
            Account.AuthTokens.Remove(this);
        }

        public Account GetAssociatedAccount(IDateTimeService dateTimeService)
        {
            if (LastUsed == dateTimeService.GetCurrentDateTime().Subtract(new TimeSpan(30, 0, 0, 0, 0)))
            {
                Account.AuthTokens.Remove(this);
                throw new Exception("Token expired.");
            }

            LastUsed = dateTimeService.GetCurrentDateTime();
            return Account;
        }
    }
}
