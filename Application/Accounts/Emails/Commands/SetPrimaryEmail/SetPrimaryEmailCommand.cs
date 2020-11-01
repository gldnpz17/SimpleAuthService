using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Emails.Commands.SetPrimaryEmail
{
    public class SetPrimaryEmailCommand : IRequest
    {
        public Guid AccountId { get; set; }
        public string Email { get; set; }
    }
}
