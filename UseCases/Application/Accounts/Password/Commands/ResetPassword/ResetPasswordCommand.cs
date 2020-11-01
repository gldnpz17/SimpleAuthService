using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Password.Commands.ResetPassword
{
    public class ResetPasswordCommand : IRequest
    {
        public Guid AccountId { get; set; }
        public string ResetToken { get; set; }
        public string NewPassword { get; set; }
    }
}
