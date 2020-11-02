using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using Domain.Entities;

namespace EFCorePostgresPersistence
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
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("SIMPLE_AUTH_SERVICE_CONNECTION_STRING"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasPostgresExtension("uuid-ossp")
                .Entity<Account>(
                (b) =>
                {
                    b
                    .Property(e => e.Id)
                    .HasDefaultValueSql("uuid_generate_v4()");

                    b
                    .HasOne(e => e.PasswordCredential)
                    .WithOne(e => e.Account)
                    .OnDelete(DeleteBehavior.Cascade);

                    b
                    .HasMany(e => e.Claims)
                    .WithOne()
                    .OnDelete(DeleteBehavior.Cascade);

                    b
                    .HasMany(e => e.AuthTokens)
                    .WithOne(e => e.Account)
                    .OnDelete(DeleteBehavior.Cascade);

                    b
                    .HasMany(e => e.Emails)
                    .WithOne()
                    .OnDelete(DeleteBehavior.Cascade);
                })
                .Entity<AccountEmailAddress>(
                (b) =>
                {
                    b
                    .HasKey(e => e.EmailAddress);

                    b
                    .HasMany(e => e.VerificationTokens)
                    .WithOne(e => e.EmailAddress)
                    .OnDelete(DeleteBehavior.Cascade);
                })
                .Entity<AuthToken>(
                (b) =>
                {
                    b
                    .HasKey(e => e.TokenString);

                    b
                    .HasOne(e => e.Account)
                    .WithMany(e => e.AuthTokens)
                    .OnDelete(DeleteBehavior.Cascade);
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

                    b
                    .HasOne(e => e.EmailAddress)
                    .WithMany(e => e.VerificationTokens)
                    .OnDelete(DeleteBehavior.Cascade);
                })
                .Entity<PasswordCredential>(
                (b) => 
                {
                    b
                    .HasKey(e => e.AccountId);

                    b
                    .HasOne(e => e.Account)
                    .WithOne(e => e.PasswordCredential)
                    .OnDelete(DeleteBehavior.Cascade);

                    b
                    .HasMany(e => e.PasswordResetTokens)
                    .WithOne()
                    .OnDelete(DeleteBehavior.Cascade);
                })
                .Entity<PasswordResetToken>(
                (b) => 
                {
                    b.HasKey(e => e.ResetToken);
                });
        }
    }
}
