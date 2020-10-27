using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuthServiceDataAccess.Repositories
{
    public interface IGenericDeleteRepository<TEntity> where TEntity : class
    {
        Task Delete(TEntity entity);
    }
}
