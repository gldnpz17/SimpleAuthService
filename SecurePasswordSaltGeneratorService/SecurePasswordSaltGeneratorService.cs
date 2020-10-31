using Domain.Services;
using System;
using System.Security.Cryptography;

namespace SecurePasswordSaltGeneratorService
{
    public class SecurePasswordSaltGeneratorService : ISecurePasswordSaltGeneratorService
    {
        public string GenerateSalt()
        {
            var cryptoRng = new RNGCryptoServiceProvider();

            var salt = new byte[64];

            cryptoRng.GetBytes(salt);

            return Convert.ToBase64String(salt);
        }
    }
}
