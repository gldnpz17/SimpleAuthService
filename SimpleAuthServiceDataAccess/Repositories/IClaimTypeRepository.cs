using SimpleAuthServiceDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuthServiceDataAccess.Repositories
{
    public interface IClaimTypeRepository :
        IGenericCreateRepository<ClaimTypeEntity>,
        IGenericReadAllRepository<ClaimTypeEntity>,
        IGenericDeleteRepository<ClaimTypeEntity>
    {
        Task<ClaimTypeEntity> ReadClaimTypeByClaimTypeName(string claimTypeName);
    }
}
