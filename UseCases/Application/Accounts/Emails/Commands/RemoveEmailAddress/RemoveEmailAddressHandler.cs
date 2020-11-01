using ApplicationDependencies.UnitOfWork;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Accounts.Emails.Commands.RemoveEmailAddress
{
    internal class RemoveEmailAddressHandler : IRequestHandler<RemoveEmailAddressCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveEmailAddressHandler(
            IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(RemoveEmailAddressCommand request, CancellationToken cancellationToken)
        {
            var account = await _unitOfWork.Accounts.ReadByIdAsync(request.AccountId);

            account.Emails.Remove(account.Emails.Where(i => i.EmailAddress == request.EmailAddress).First());

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
