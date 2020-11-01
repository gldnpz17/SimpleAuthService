using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public interface IAlphanumericTokenGenerator
    {
        string GenerateAlphanumericToken(int length);
    }
}
