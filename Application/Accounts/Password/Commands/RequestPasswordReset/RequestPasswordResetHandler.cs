using Application.Common.External.UnitOfWork;
using Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Accounts.Password.Commands.RequestPasswordReset
{
    internal class RequestPasswordResetHandler : IRequestHandler<RequestPasswordResetCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordResetTokenSenderService _passwordResetTokenSenderService;
        private readonly IAlphanumericTokenGenerator _alphanumericTokenGenerator;

        public RequestPasswordResetHandler(
            IUnitOfWork unitOfWork,
            IPasswordResetTokenSenderService passwordResetTokenSenderService,
            IAlphanumericTokenGenerator alphanumericTokenGenerator)
        {
            _unitOfWork = unitOfWork;
            _passwordResetTokenSenderService = passwordResetTokenSenderService;
            _alphanumericTokenGenerator = alphanumericTokenGenerator;
        }

        public async Task<Unit> Handle(RequestPasswordResetCommand request, CancellationToken cancellationToken)
        {
            var account = await _unitOfWork.Accounts.ReadByIdAsync(request.AccountId);

            account.PasswordCredential.SendResetRequest(_passwordResetTokenSenderService, _alphanumericTokenGenerator);

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
