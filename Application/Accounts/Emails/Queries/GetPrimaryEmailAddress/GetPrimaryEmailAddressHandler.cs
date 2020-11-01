using Application.Accounts.Emails.Queries.DTOs;
using ApplicationDependencies.UnitOfWork;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Accounts.Emails.Queries.GetPrimaryEmailAddress
{
    internal class GetPrimaryEmailAddressHandler : IRequestHandler<GetPrimaryEmailAddressQuery, EmailAddressDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPrimaryEmailAddressHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        async Task<EmailAddressDto> IRequestHandler<GetPrimaryEmailAddressQuery, EmailAddressDto>.Handle(GetPrimaryEmailAddressQuery request, CancellationToken cancellationToken)
        {
            var account = await _unitOfWork.Accounts.ReadByIdAsync(request.AccountId);

            return _mapper.Map<EmailAddressDto>(account.PrimaryEmail);
        }
    }
}
