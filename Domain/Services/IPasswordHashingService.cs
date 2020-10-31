using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public interface IPasswordHashingService
    {
        string HashPassword(string password, string salt);
    }
}
