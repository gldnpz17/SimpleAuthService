using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.External.UnitOfWork.Repositories
{
    internal interface IDeleteRepository<TEntity> where TEntity : class
    {
        Task DeleteAsync(TEntity entity);
    }
}
