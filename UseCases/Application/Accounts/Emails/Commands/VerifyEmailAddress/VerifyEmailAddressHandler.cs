using ApplicationDependencies.UnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Accounts.Emails.Commands.VerifyEmailAddress
{
    internal class VerifyEmailAddressHandler : IRequestHandler<VerifyEmailAddressCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public VerifyEmailAddressHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(VerifyEmailAddressCommand request, CancellationToken cancellationToken)
        {
            var matchingToken = await _unitOfWork.EmailVerificationTokens.ReadByVerificationTokenAsync(request.VerificationCode);

            var email = matchingToken.EmailAddress;

            email.VerifyEmail(matchingToken);

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
