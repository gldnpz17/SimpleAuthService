using MediatR;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Application.Accounts.Emails.Commands.TryToVerifyEmailAddress
{
    public class TryToVerifyEmailAddressCommand : IRequest
    {
        public Guid AccountId { get; set; }
        public string EmailAddress { get; set; }
    }
}
