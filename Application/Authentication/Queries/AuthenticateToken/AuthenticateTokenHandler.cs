using Application.Authentication.Queries.DTOs;
using ApplicationDependencies.UnitOfWork;
using AutoMapper;
using Domain.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Authentication.Queries.AuthenticateToken
{
    internal class AuthenticateTokenHandler : IRequestHandler<AuthenticateTokenQuery, AccountDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeService _dateTimeService;
        private readonly IMapper _mapper;

        public AuthenticateTokenHandler(
            IUnitOfWork unitOfWork,
            IDateTimeService dateTimeService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _dateTimeService = dateTimeService;
            _mapper = mapper;
        }

        public async Task<AccountDto> Handle(AuthenticateTokenQuery request, CancellationToken cancellationToken)
        {
            var authentication = await _unitOfWork.Authentication.GetAuthenticationAsync();

            var result = authentication.VerifyAuthToken(request.AuthToken, _dateTimeService);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<AccountDto>(result);
        }
    }
}
