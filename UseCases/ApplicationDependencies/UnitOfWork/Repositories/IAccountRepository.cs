using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDependencies.UnitOfWork.Repositories
{
    public interface IAccountRepository :
        IGenericCreateRepository<Account>,
        IGenericDeleteRepository<Account>,
        IGenericReadAllRepository<Account>
    {
        Task<Account> ReadByIdAsync(Guid id);
    }
}
