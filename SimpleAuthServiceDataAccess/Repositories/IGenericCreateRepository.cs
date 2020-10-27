using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuthServiceDataAccess.Repositories
{
    public interface IGenericCreateRepository<TEntity> where TEntity : class
    {
        Task CreateAsync(TEntity entity);
    }
}
