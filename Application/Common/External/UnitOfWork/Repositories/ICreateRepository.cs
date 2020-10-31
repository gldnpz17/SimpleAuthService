using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.External.UnitOfWork.Repositories
{
    internal interface ICreateRepository<TEntity> where TEntity : class
    {
        Task CreateAsync(TEntity entity);
    }
}
