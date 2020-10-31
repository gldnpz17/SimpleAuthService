using Domain.Services;
using System;
using System.Linq;

namespace Application.Common.ApplicationServices.AlphanumericTokenGenerator
{
    public class AlphanumericTokenGenerator : IAlphanumericTokenGenerator
    {
        private readonly string CharacterSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public string GenerateAlphanumericToken(int length)
        {
            Random random = new Random();

            return new string(Enumerable.Repeat(CharacterSet, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
