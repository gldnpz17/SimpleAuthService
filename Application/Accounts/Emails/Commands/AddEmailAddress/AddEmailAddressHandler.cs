using Application.Common.External.UnitOfWork;
using Domain.Entities;
using Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Accounts.Emails.Commands.AddEmailAddress
{
    internal class AddEmailAddressHandler : IRequestHandler<AddEmailAddressCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailVerifierService _emailVerifierService;
        private readonly IAlphanumericTokenGenerator _alphanumericTokenGenerator;

        public AddEmailAddressHandler(
            IUnitOfWork unitOfWork,
            IEmailVerifierService emailVerifierService,
            IAlphanumericTokenGenerator alphanumericTokenGenerator)
        {
            _unitOfWork = unitOfWork;
            _emailVerifierService = emailVerifierService;
            _alphanumericTokenGenerator = alphanumericTokenGenerator;
        }

        public async Task<Unit> Handle(AddEmailAddressCommand request, CancellationToken cancellationToken)
        {
            var account = await _unitOfWork.Accounts.ReadByIdAsync(request.AccountId);

            var newEmailAddress = new AccountEmailAddress()
            {
                EmailAddress = request.EmailAddress,
                IsVerified = false
            };

            account.Emails.Add(newEmailAddress);

            await _unitOfWork.SaveChangesAsync();

            newEmailAddress.SendVerificationRequest(_emailVerifierService, _alphanumericTokenGenerator);

            return Unit.Value;
        }
    }
}
