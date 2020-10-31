using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Authentication.Commands.Logout
{
    public class LogoutCommand : IRequest
    {
        public string AuthToken { get; set; }
    }
}
