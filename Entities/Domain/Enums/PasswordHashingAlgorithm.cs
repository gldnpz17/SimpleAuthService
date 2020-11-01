using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Enums
{
    public enum PasswordHashingAlgorithm
    {
        PBKDF2,
        BCrypt,
        Argon2id
    }
}
