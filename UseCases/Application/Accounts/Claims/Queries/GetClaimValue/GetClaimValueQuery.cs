using Application.Accounts.Claims.Queries.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Claims.Queries.GetClaimValue
{
    public class GetClaimValueQuery : IRequest<ClaimDto>
    {
        public Guid AccountId { get; set; }
        public string ClaimName { get; set; }
    }
}
