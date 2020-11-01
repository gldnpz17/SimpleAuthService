using Application.Accounts.Claims.Queries.DTOs;
using ApplicationDependencies.UnitOfWork;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Accounts.Claims.Queries.GetAllClaims
{
    internal class GetAllClaimsHandler : IRequestHandler<GetAllClaimsQuery, List<ClaimDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllClaimsHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ClaimDto>> Handle(GetAllClaimsQuery request, CancellationToken cancellationToken)
        {
            var output = new List<ClaimDto>();

            var account = await _unitOfWork.Accounts.ReadByIdAsync(request.AccountId);

            account.Claims.ToList().ForEach(i => output.Add(_mapper.Map<ClaimDto>(i)));

            return output;
        }
    }
}
