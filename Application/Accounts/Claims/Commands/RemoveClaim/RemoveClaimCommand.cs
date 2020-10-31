using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Claims.Commands.RemoveClaim
{
    public class RemoveClaimCommand : IRequest
    {
        public Guid AccountId { get; set; }
        public string ClaimName { get; set; }
    }
}
