using Domain.Enums;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class PasswordCredential
    {
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        public string HashedPassword { get; set; }
        public string PasswordSalt { get; set; }
        public PasswordHashingAlgorithm PasswordHashingAlgorithm { get; set; }
        public IList<PasswordResetToken> PasswordResetTokens { get; private set; } = new List<PasswordResetToken>();

        public void SetPassword(
            string password, 
            IPasswordHashingService passwordHasher, 
            ISecureRandomStringGeneratorService saltGenerator)
        {
            PasswordSalt = saltGenerator.GenerateSecureRandomString();
            HashedPassword = passwordHasher.HashPassword(password, PasswordSalt);
        }

        public void SendResetRequest(
            IPasswordResetTokenSenderService passwordResetTokenSender, 
            IAlphanumericTokenGenerator tokenGenerator)
        {
            //disable previous reset tokens
            PasswordResetTokens?.ToList().ForEach(i => i.IsActive = false);

            var newResetToken = 
                new PasswordResetToken()
                {
                    ResetToken = tokenGenerator.GenerateAlphanumericToken(64),
                    IsActive = true
                };

            PasswordResetTokens.Add(newResetToken);

            passwordResetTokenSender.SendResetToken(
                Account.PrimaryEmail,
                newResetToken
                );
        }

        public void ResetPassword(
            string newPassword, 
            IPasswordHashingService passwordHasher, 
            PasswordResetToken resetToken,
            ISecureRandomStringGeneratorService saltGenerator)
        {
            if (PasswordResetTokens.Contains(resetToken) && resetToken.IsActive)
            {
                PasswordSalt = saltGenerator.GenerateSecureRandomString();
                HashedPassword = passwordHasher.HashPassword(newPassword, PasswordSalt);
            }
        }
    }
}
