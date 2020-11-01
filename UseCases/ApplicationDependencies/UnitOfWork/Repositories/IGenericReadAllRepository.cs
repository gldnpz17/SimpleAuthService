using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDependencies.UnitOfWork.Repositories
{
    public interface IGenericReadAllRepository<TEntity> where TEntity : class
    {
        Task<IList<TEntity>> ReadAllAsync();
    }
}
