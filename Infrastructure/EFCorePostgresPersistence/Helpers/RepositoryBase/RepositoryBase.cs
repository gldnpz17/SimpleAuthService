using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePostgresPersistence.Helpers.RepositoryBase
{
    internal class RepositoryBase
    {
        protected AppDbContext _appDbContext;

        public RepositoryBase(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public virtual async Task SaveChangesAsync() 
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
