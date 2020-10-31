using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Domain.Entities
{
    public class Authentication
    {
        public IList<AuthToken> AuthTokens { get; private set; } = new List<AuthToken>();
        public IList<Account> Accounts { get; private set; } = new List<Account>();

        public AuthToken PasswordLogin(
            string username, 
            string password, 
            IPasswordHashingService passwordHasher, 
            IAlphanumericTokenGenerator alphanumericTokenGenerator,
            IDateTimeService dateTimeService) 
        {
            var account = Accounts.First(i => i.Username == username);

            if (account == null)
            {
                throw new Exception("Incorrect Username or Password.");
            }
            else
            {
                var accountSalt = account.PasswordCredential.PasswordSalt;
                if (account.PasswordCredential.HashedPassword == passwordHasher.HashPassword(password, accountSalt))
                {
                    var newAuthToken =
                        new AuthToken()
                        {
                            TokenString = alphanumericTokenGenerator.GenerateAlphanumericToken(64),
                            LastUsed = dateTimeService.GetCurrentDateTime(),
                            Account = account
                        };

                    AuthTokens.Add(newAuthToken);

                    return newAuthToken;
                }
                else
                {
                    throw new Exception("Incorrect Username or Password.");
                }
            }
        }

        public void Logout(string authToken, IDateTimeService dateTimeService)
        {
            var matchingAuthToken = AuthTokens.First(i => i.TokenString == authToken);

            if (matchingAuthToken == null)
            {
                throw new Exception("Invalid Token.");
            }
            if (matchingAuthToken.LastUsed == dateTimeService.GetCurrentDateTime().Subtract(new TimeSpan(30, 0, 0, 0, 0)))
            {
                AuthTokens.Remove(matchingAuthToken);
                throw new Exception("Token expired.");
            }

            AuthTokens.Remove(matchingAuthToken);
        }

        public Account VerifyAuthToken(string authToken, IDateTimeService dateTimeService) 
        {
            var matchingAuthToken = AuthTokens.First(i => i.TokenString == authToken);

            if (matchingAuthToken == null)
            {
                throw new Exception("Invalid Token.");
            }
            if (matchingAuthToken.LastUsed == dateTimeService.GetCurrentDateTime().Subtract(new TimeSpan(30, 0, 0, 0, 0)))
            {
                AuthTokens.Remove(matchingAuthToken);
                throw new Exception("Token expired.");
            }

            matchingAuthToken.LastUsed = dateTimeService.GetCurrentDateTime();
            return matchingAuthToken.Account;
        }
    }
}
