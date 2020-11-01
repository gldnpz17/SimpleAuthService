using Application.Authentication.Queries.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Authentication.Queries.PasswordLogin
{
    public class PasswordLoginQuery : IRequest<AuthTokenDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
