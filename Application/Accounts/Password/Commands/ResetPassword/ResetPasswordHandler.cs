using ApplicationDependencies.UnitOfWork;
using Domain.Services;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Accounts.Password.Commands.ResetPassword
{
    internal class ResetPasswordHandler : IRequestHandler<ResetPasswordCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHashingService _passwordHashingService;
        private readonly ISecurePasswordSaltGeneratorService _securePasswordSaltGenerator;

        public ResetPasswordHandler(
            IUnitOfWork unitOfWork,
            IPasswordHashingService passwordHashingService,
            ISecurePasswordSaltGeneratorService securePasswordSaltGenerator)
        {
            _unitOfWork = unitOfWork;
            _passwordHashingService = passwordHashingService;
            _securePasswordSaltGenerator = securePasswordSaltGenerator;
        }

        public async Task<Unit> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var account =  await _unitOfWork.Accounts.ReadByIdAsync(request.AccountId);

            var resetToken = account.PasswordCredential.PasswordResetTokens.First(i => i.ResetToken == request.ResetToken);

            account.PasswordCredential.ResetPassword(request.NewPassword, _passwordHashingService, resetToken, _securePasswordSaltGenerator);

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
