using Application.Accounts.Claims.Queries.DTOs;
using ApplicationDependencies.UnitOfWork;
using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Accounts.Claims.Queries.GetClaimValue
{
    internal class GetClaimValueHandler : IRequestHandler<GetClaimValueQuery, ClaimDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetClaimValueHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ClaimDto> Handle(GetClaimValueQuery request, CancellationToken cancellationToken)
        {
            var account = await _unitOfWork.Accounts.ReadByIdAsync(request.AccountId);

            return _mapper.Map<ClaimDto>(account.Claims.Where(i => i.Name == request.ClaimName).First());
        }
    }
}
