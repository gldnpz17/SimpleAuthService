using ApplicationDependencies.UnitOfWork;
using Domain.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Authentication.Commands.Logout
{
    internal class LogoutHandler : IRequestHandler<LogoutCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeService _dateTimeService;

        public LogoutHandler(
            IUnitOfWork unitOfWork,
            IDateTimeService dateTimeService)
        {
            _unitOfWork = unitOfWork;
            _dateTimeService = dateTimeService;
        }

        public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            var authentication = await _unitOfWork.Authentication.GetAuthenticationAsync();
            
            authentication.Logout(request.AuthToken, _dateTimeService);

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
