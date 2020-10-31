using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Emails.Commands.VerifyEmailAddress
{
    public class VerifyEmailAddressCommand : IRequest
    {
        public string VerificationCode { get; set; }
    }
}
