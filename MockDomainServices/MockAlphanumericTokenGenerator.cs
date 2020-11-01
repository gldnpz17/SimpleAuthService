using Domain.Services;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MockDomainServices
{

    public class MockAlphanumericTokenGenerator : IAlphanumericTokenGenerator
    {
        private readonly List<string> _alphanumericString;

        public string GenerateAlphanumericToken(int length)
        {
            string output = "";

            for (int x = 0; x < length; x++)
            {
                output += "x";
            }

            return output;
        }
    }
}
