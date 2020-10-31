using Application.Accounts.Claims.Queries.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Claims.Queries.GetAllClaims
{
    public class GetAllClaimsQuery : IRequest<List<ClaimDto>>
    {
        public Guid AccountId { get; set; } 
    }
}
