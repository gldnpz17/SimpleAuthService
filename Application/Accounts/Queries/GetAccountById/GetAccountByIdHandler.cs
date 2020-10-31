﻿using Application.Accounts.Queries.DTOs.GetAccountById;
using Application.Common.External.UnitOfWork;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Accounts.Queries.GetAccountById
{
    internal class GetAccountByIdHandler : IRequestHandler<GetAccountByIdQuery, AccountDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAccountByIdHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AccountDto> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<AccountDto>(await _unitOfWork.Accounts.ReadByIdAsync(request.Id));
        }
    }
}