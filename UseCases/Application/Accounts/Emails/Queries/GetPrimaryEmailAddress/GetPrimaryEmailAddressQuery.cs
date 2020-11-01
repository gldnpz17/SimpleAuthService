using Application.Accounts.Emails.Queries.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Emails.Queries.GetPrimaryEmailAddress
{
    public class GetPrimaryEmailAddressQuery : IRequest<EmailAddressDto>
    {
        public Guid AccountId { get; set; }
    }
}
