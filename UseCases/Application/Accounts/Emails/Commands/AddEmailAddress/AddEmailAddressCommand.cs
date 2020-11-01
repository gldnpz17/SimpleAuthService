using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Emails.Commands.AddEmailAddress
{
    public class AddEmailAddressCommand : IRequest
    {
        public Guid AccountId { get; set; }
        public string EmailAddress { get; set; }
    }
}
