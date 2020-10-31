using Application.Common.External.UnitOfWork;
using Application.Common.External.UnitOfWork.Repositories.Accounts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Accounts.Commands.ChangeUsername
{
    internal class UpdateUsernameHandler : IRequestHandler<UpdateUsernameCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        internal UpdateUsernameHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateUsernameCommand request, CancellationToken cancellationToken)
        {
            var account = await _unitOfWork.Accounts.ReadByIdAsync(request.Id);
            
            account.Username = request.NewUsername;

            await _unitOfWork.Accounts.UpdateAsync(account);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
