using SimpleAuthServiceDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuthServiceDataAccess.Repositories
{
    public interface IClaimTagRepository :
        IGenericCreateRepository<ClaimTagEntity>,
        IGenericReadAllRepository<ClaimTagEntity>,
        IGenericDeleteRepository<ClaimTagEntity>
    {
        Task<IEnumerable<ClaimTagEntity>> ReadByClaimNameAsync(string claimName);
        Task<ClaimTagEntity> ReadClaimTagByClaimNameAndClaimTagNameAsync(string claimName, string claimTagName);
    }
}
