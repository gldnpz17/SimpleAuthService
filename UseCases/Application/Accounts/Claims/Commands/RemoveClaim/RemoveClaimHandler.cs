using ApplicationDependencies.UnitOfWork;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Accounts.Claims.Commands.RemoveClaim
{
    internal class RemoveClaimHandler : IRequestHandler<RemoveClaimCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveClaimHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(RemoveClaimCommand request, CancellationToken cancellationToken)
        {
            var account = await _unitOfWork.Accounts.ReadByIdAsync(request.AccountId);

            account.Claims.Remove(account.Claims.First(i => i.Name == request.ClaimName));

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
