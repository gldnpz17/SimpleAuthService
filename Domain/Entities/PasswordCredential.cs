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
        public Account Account { get; set; }
        public string HashedPassword { get; set; }
        public string PasswordSalt { get; set; }
        public PasswordHashingAlgorithm PasswordHashingAlgorithm { get; set; }
        public IList<PasswordResetToken> PasswordResetTokens { get; set; }

        public void SetPassword(
            string password, 
            IPasswordHashingService passwordHasher, 
            ISecurePasswordSaltGeneratorService saltGenerator)
        {
            PasswordSalt = saltGenerator.GenerateSalt();
            HashedPassword = passwordHasher.HashPassword(password, PasswordSalt);
        }

        public void SendResetRequest(
            IPasswordResetTokenSenderService passwordResetTokenSender, 
            IAlphanumericTokenGenerator tokenGenerator)
        {
            //disable previous reset tokens
            PasswordResetTokens.ToList().ForEach(i => i.IsActive = false);

            passwordResetTokenSender.SendResetToken(
                Account.PrimaryEmail,
                new PasswordResetToken()
                {
                    ResetToken = tokenGenerator.GenerateAlphanumericToken(64),
                    IsActive = true
                });
        }

        public void ResetPassword(
            string newPassword, 
            IPasswordHashingService passwordHasher, 
            PasswordResetToken resetToken,
            ISecurePasswordSaltGeneratorService saltGenerator)
        {
            if (PasswordResetTokens.Contains(resetToken) && resetToken.IsActive)
            {
                PasswordSalt = saltGenerator.GenerateSalt();
                HashedPassword = passwordHasher.HashPassword(newPassword, PasswordSalt);
            }
        }
    }
}
