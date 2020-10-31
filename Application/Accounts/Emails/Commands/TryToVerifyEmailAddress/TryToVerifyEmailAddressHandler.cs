using ApplicationDependencies.UnitOfWork;
using Domain.Services;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Accounts.Emails.Commands.TryToVerifyEmailAddress
{
    internal class TryToVerifyEmailAddressHandler : IRequestHandler<TryToVerifyEmailAddressCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailVerifierService _emailVerifierService;
        private readonly IAlphanumericTokenGenerator _alphanumericTokenGenerator;

        public TryToVerifyEmailAddressHandler(
            IUnitOfWork unitOfWork,
            IEmailVerifierService emailVerifierService,
            IAlphanumericTokenGenerator alphanumericTokenGenerator)
        {
            _unitOfWork = unitOfWork;
            _emailVerifierService = emailVerifierService;
            _alphanumericTokenGenerator = alphanumericTokenGenerator;
        }

        public async Task<Unit> Handle(TryToVerifyEmailAddressCommand request, CancellationToken cancellationToken)
        {
            var account = await _unitOfWork.Accounts.ReadByIdAsync(request.AccountId);

            account.Emails.Where(i => i.EmailAddress == request.EmailAddress).First().SendVerificationRequest(_emailVerifierService, _alphanumericTokenGenerator);

            return Unit.Value;
        }
    }
}
