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
            optionsBuilder.UseNpgsql("User ID = postgres; Password = SuperSekrit; Host = localhost; Port = 5432; Database = SimplAuthServiceDevDB;");
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
