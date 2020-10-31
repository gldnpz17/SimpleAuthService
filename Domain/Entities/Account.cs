using Domain.Helpers;
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

        public Guid Id { get; set; }

        public string Username { get; set; }

        public PasswordCredential PasswordCredential { get; set; }

        public IList<Claim> Claims { get; private set; } = new List<Claim>();

        private ListProxy<AccountEmailAddress> _emails = new ListProxy<AccountEmailAddress>(new List<AccountEmailAddress>());
        public IList<AccountEmailAddress> Emails 
        {
            get
            {
                return _emails;
            }
        }

        private AccountEmailAddress _primaryEmail;
        public AccountEmailAddress PrimaryEmail 
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
    }
}
