using ApiKeyPersistence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using System.Diagnostics;

namespace ApiKeyPersistence
{
    public class ApiKeyDbContext : DbContext
    {
        public DbSet<ApiKey> ApiKeys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("API_KEY_CONNECTION_STRING"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ApiKey>(
                (b) =>
                {
                    b.HasKey(e => e.KeyString);
                });
        }
    }
}
