using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Commands.DeleteAccount
{
    public class DeleteAccountCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
