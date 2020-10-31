using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Accounts.Commands.ChangeUsername
{
    public class UpdateUsernameCommand : IRequest
    {
        public Guid Id { get; set; }
        public string NewUsername { get; set; }
    }
}
