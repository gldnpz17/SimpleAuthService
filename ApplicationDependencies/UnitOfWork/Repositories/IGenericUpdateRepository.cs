using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDependencies.UnitOfWork.Repositories
{
    public interface IGenericUpdateRepository<TEntity> where TEntity : class
    {
        Task UpdateAsync(TEntity entity);
    }
}
