using ApplicationDependencies.UnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Accounts.Commands.DeleteAccount
{
    internal class DeleteAccountHandler : IRequestHandler<DeleteAccountCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAccountHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await _unitOfWork.Accounts.ReadByIdAsync(request.Id);

            await _unitOfWork.Accounts.DeleteAsync(account);

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
