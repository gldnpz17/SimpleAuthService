using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace EFCoreInMemoryPersistence
{
    class AppDbContext : DbContext
    {
        public DbSet<Domain.Entities.Account> Accounts { get; set; }
        public DbSet<Domain.Entities.AccountEmailAddress> AccountEmailAddresses { get; set; }
        public DbSet<Domain.Entities.AuthToken> AuthTokens { get; set; }
        public DbSet<Domain.Entities.Claim> Claims { get; set; }
        public DbSet<Domain.Entities.EmailVerificationToken> EmailVerificationTokens { get; set; }
        public DbSet<Domain.Entities.PasswordCredential> PasswordCredentials { get; set; }
        public DbSet<Domain.Entities.PasswordResetToken> PasswordResetTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "TestDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Account>(
                (b) =>
                {
                    b
                    .Property(e => e.Id);
                })
                .Entity<AccountEmailAddress>(
                (b) =>
                {
                    b
                    .HasKey(e => e.EmailAddress);
                })
                .Entity<AuthToken>(
                (b) =>
                {
                    b
                    .HasKey(e => e.TokenString);
                })
                .Entity<Claim>(
                (b) =>
                {
                    b
                    .HasKey(e => e.Name);
                })
                .Entity<EmailVerificationToken>(
                (b) =>
                {
                    b
                    .HasKey(e => e.VerificationToken);
                })
                .Entity<PasswordCredential>(
                (b) =>
                {
                    b
                    .HasKey(e => e.AccountId);
                })
                .Entity<PasswordResetToken>(
                (b) =>
                {
                    b.HasKey(e => e.ResetToken);
                });
        }
    }
}
