using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDependencies.UnitOfWork.Repositories
{
    public interface IDeleteRepository<TEntity> where TEntity : class
    {
        Task DeleteAsync(TEntity entity);
    }
}
