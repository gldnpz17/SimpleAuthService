using ApiSecurityPersistence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSecurityPersistence
{
    public class ApiSecurityDbContext : DbContext
    {
        public DbSet<ApiKey> ApiKeys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "TestSecurityDB");
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
