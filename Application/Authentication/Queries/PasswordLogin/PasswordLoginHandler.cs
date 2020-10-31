using Application.Authentication.Queries.DTOs;
using ApplicationDependencies.UnitOfWork;
using AutoMapper;
using Domain.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Authentication.Queries.PasswordLogin
{
    internal class PasswordLoginHandler : IRequestHandler<PasswordLoginQuery, AuthTokenDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHashingService _passwordHashingService;
        private readonly IAlphanumericTokenGenerator _alphanumericTokenGenerator;
        private readonly IDateTimeService _dateTimeService;
        private readonly IMapper _mapper;

        public PasswordLoginHandler(
            IUnitOfWork unitOfWork,
            IPasswordHashingService passwordHashingService,
            IAlphanumericTokenGenerator alphanumericTokenGenerator,
            IDateTimeService dateTimeService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _passwordHashingService = passwordHashingService;
            _alphanumericTokenGenerator = alphanumericTokenGenerator;
            _dateTimeService = dateTimeService;
            _mapper = mapper;
        }

        public async Task<AuthTokenDto> Handle(PasswordLoginQuery request, CancellationToken cancellationToken)
        {
            var authentication = await _unitOfWork.Authentication.GetAuthenticationAsync();

            var result = authentication.PasswordLogin(
                request.Username, 
                request.Password, 
                _passwordHashingService, 
                _alphanumericTokenGenerator, 
                _dateTimeService);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<AuthTokenDto>(result);
        }
    }
}
