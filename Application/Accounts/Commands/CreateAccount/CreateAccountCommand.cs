using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommand : IRequest
    {
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
