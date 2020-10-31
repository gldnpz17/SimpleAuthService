﻿using Domain.Services;
using System;
using System.Security.Cryptography;
using System.Text;

namespace PasswordHashingService
{
    public class PasswordHashingService : IPasswordHashingService
    {
        public string HashPassword(string password, string salt)
        {
            var hashedPassword = new Rfc2898DeriveBytes(
                Encoding.UTF8.GetBytes(password),
                Convert.FromBase64String(salt),
                1024);

            return Convert.ToBase64String(hashedPassword.GetBytes(256));
        }
    }
}
