using Domain.Helpers;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Account
    {   
        public Account()
        {
            _emails.RemoveAction =
                (item, list) =>
                {
                    if (item == _primaryEmail)
                    {
                        throw new Exception("Cannot remove primary email.");
                    }
                    else
                    {
                        return list.Remove(item);
                    }
                };
        }

        public virtual Guid Id { get; set; }

        public virtual string Username { get; set; }

        public virtual PasswordCredential PasswordCredential { get; set; }

        public virtual IList<Claim> Claims { get; private set; } = new List<Claim>();

        public virtual IList<AuthToken> AuthTokens { get; private set; } = new List<AuthToken>();

        private ListProxy<AccountEmailAddress> _emails = new ListProxy<AccountEmailAddress>(new List<AccountEmailAddress>());
        public virtual IList<AccountEmailAddress> Emails 
        {
            get
            {
                return _emails;
            }
        }

        private AccountEmailAddress _primaryEmail;
        public virtual AccountEmailAddress PrimaryEmail 
        {
            get 
            {
                return _primaryEmail;
            }
            set
            {
                if (!_emails.Contains(value))
                {
                    throw new Exception("email not registered in this account.");
                }
                else
                {
                    _primaryEmail = value;
                }
            } 
        }

        public AuthToken GetAuthToken(
            string password,
            IPasswordHashingService passwordHasher,
            IAlphanumericTokenGenerator alphanumericTokenGenerator,
            IDateTimeService dateTimeService)
        {
            var accountSalt = PasswordCredential.PasswordSalt;
            if (PasswordCredential.HashedPassword == passwordHasher.HashPassword(password, accountSalt))
            {
                var newAuthToken =
                    new AuthToken()
                    {
                        TokenString = alphanumericTokenGenerator.GenerateAlphanumericToken(64),
                        LastUsed = dateTimeService.GetCurrentDateTime(),
                        Account = this
                    };

                AuthTokens.Add(newAuthToken);

                return newAuthToken;
            }
            else
            {
                throw new Exception("Incorrect Username or Password.");
            }
            
        }
    }
}
