using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.External.UnitOfWork.Repositories.Accounts
{
    internal interface IAccountRepository :
        ICreateRepository<Account>,
        IUpdateRepository<Account>,
        IDeleteRepository<Account>,
        IReadAllRepository<Account>
    {
        Task<Account> ReadByIdAsync(Guid id);
    }
}
