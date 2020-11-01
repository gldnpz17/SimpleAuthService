using ApplicationDependencies.UnitOfWork;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Accounts.Emails.Commands.SetPrimaryEmail
{
    internal class SetPrimaryEmailHandler : IRequestHandler<SetPrimaryEmailCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SetPrimaryEmailHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(SetPrimaryEmailCommand request, CancellationToken cancellationToken)
        {
            var account = await _unitOfWork.Accounts.ReadByIdAsync(request.AccountId);

            var email = account.Emails.First(i => i.EmailAddress == request.Email);

            account.PrimaryEmail = email;

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
