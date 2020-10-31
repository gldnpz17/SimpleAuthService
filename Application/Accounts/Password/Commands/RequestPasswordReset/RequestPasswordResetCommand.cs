using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Password.Commands.RequestPasswordReset
{
    public class RequestPasswordResetCommand : IRequest
    {
        public Guid AccountId { get; set; }
    }
}
