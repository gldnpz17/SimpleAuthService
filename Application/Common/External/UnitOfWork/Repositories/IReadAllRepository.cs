using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.External.UnitOfWork.Repositories
{
    internal interface IReadAllRepository<TEntity> where TEntity : class
    {
        Task<IList<TEntity>> ReadAllAsync();
    }
}
