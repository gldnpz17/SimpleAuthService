﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDependencies.UnitOfWork.Repositories
{
    public interface IAuthenticationRepository
    {
        Task<Authentication> GetAuthenticationAsync();
    }
}
