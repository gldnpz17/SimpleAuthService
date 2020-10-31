using Application.Common.External.UnitOfWork;
using Domain.Entities;
using Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Accounts.Commands.CreateAccount
{
    internal class CreateAccountHandler : IRequestHandler<CreateAccountCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHashingService _passwordHashingService;
        private readonly IEmailVerifierService _emailVerifierService;
        private readonly IAlphanumericTokenGenerator _alphanumericTokenGenerator;
        private readonly ISecurePasswordSaltGeneratorService _securePasswordSaltGenerator;

        internal CreateAccountHandler(
            IUnitOfWork unitOfWork,
            IPasswordHashingService passwordHashingService,
            IEmailVerifierService emailVerifierService,
            IAlphanumericTokenGenerator alphanumericTokenGenerator,
            ISecurePasswordSaltGeneratorService securePasswordSaltGenerator)
        {
            _unitOfWork = unitOfWork;
            _passwordHashingService = passwordHashingService;
            _emailVerifierService = emailVerifierService;
            _alphanumericTokenGenerator = alphanumericTokenGenerator;
            _securePasswordSaltGenerator = securePasswordSaltGenerator;
        }

        public async Task<Unit> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var newPassword = new PasswordCredential();
            newPassword.SetPassword(request.Password, _passwordHashingService, _securePasswordSaltGenerator);

            var newEmailAddress = new AccountEmailAddress() 
            {
                EmailAddress = request.EmailAddress
            };

            var newAccount = new Account()
            {
                Username = request.Username,
                PasswordCredential = newPassword
            };

            newAccount.Emails.Add(newEmailAddress);
            newAccount.PrimaryEmail = newEmailAddress;

            await _unitOfWork.Accounts.CreateAsync(newAccount);
            await _unitOfWork.SaveChangesAsync();

            newEmailAddress.SendVerificationRequest(_emailVerifierService, _alphanumericTokenGenerator);

            return Unit.Value;
        }
    }
}
