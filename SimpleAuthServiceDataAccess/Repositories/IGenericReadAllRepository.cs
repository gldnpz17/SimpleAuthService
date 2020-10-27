using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuthServiceDataAccess.Repositories
{
    public interface IGenericReadAllRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> ReadAllAsync();
    }
}
