using ApplicationDependencies.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Accounts.Claims.Commands.UpdateClaimValue
{
    internal class UpdateClaimValueHandler : IRequestHandler<UpdateClaimValueCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateClaimValueHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateClaimValueCommand request, CancellationToken cancellationToken)
        {
            var account = await _unitOfWork.Accounts.ReadByIdAsync(request.AccountId);

            account.Claims.First(i => i.Name == request.ClaimName).Value = request.ClaimValue;

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
