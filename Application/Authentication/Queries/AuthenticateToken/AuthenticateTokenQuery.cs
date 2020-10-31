using Application.Authentication.Queries.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Authentication.Queries.AuthenticateToken
{
    public class AuthenticateTokenQuery : IRequest<AccountDto>
    {
        public string AuthToken { get; set; }
    }
}
