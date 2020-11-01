using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ApplicationDependencies.UnitOfWork;

namespace Application.Accounts.Claims.Commands.AddClaim
{
    internal class AddClaimHandler : IRequestHandler<AddClaimCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddClaimHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddClaimCommand request, CancellationToken cancellationToken)
        {
            var account = await _unitOfWork.Accounts.ReadByIdAsync(request.AccountId);

            account.Claims.Add(
                new Domain.Entities.Claim()
                {
                    Name = request.ClaimName,
                    Value = request.ClaimValue
                });

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
