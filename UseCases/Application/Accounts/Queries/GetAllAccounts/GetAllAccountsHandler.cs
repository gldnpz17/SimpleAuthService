using Application.Accounts.Queries.DTOs;
using ApplicationDependencies.UnitOfWork;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Accounts.Queries.GetAllAccounts
{
    internal class GetAllAccountsHandler : IRequestHandler<GetAllAccountsQuery, List<AccountDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllAccountsHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<AccountDto>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
        {
            var output = new List<AccountDto>();

            var queryResults = await _unitOfWork.Accounts.ReadAllAsync();

            queryResults.ToList().ForEach(i => output.Add(_mapper.Map<AccountDto>(i)));

            return output;
        }
    }
}
