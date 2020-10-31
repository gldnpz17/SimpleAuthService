using Application.Accounts.Emails.Queries.DTOs;
using ApplicationDependencies.UnitOfWork;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Accounts.Emails.Queries.GetAllEmailAddresses
{
    internal class GetAllEmailAddressesHandler : IRequestHandler<GetAllEmailAddressesQuery, List<EmailAddressDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllEmailAddressesHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<EmailAddressDto>> Handle(GetAllEmailAddressesQuery request, CancellationToken cancellationToken)
        {
            var output = new List<EmailAddressDto>();

            var account = await _unitOfWork.Accounts.ReadByIdAsync(request.AccountId);

            account.Emails.ToList().ForEach(i => output.Add(_mapper.Map<EmailAddressDto>(i)));

            return output;
        }
    }
}
