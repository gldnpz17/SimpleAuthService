using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Claims.Commands.AddClaim
{
    public class AddClaimCommand : IRequest
    {
        public Guid AccountId { get; set; }
        public string ClaimName { get; set; }
        public string ClaimValue { get; set; }
    }
}
