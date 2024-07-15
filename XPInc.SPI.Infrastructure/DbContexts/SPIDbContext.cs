
using Bogus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Metadata;
using XPInc.SPI.Entities.Enum;
using XPInc.SPI.Entities.Models;
using XPInc.SPI.Infrastructure.Migrations.Seeds;

namespace XPInc.SPI.Infrastructure.DbContexts
{
    public class SPIDbContext : DbContext
    {
        public DbSet<FinantialProduct> FinantialProducts { get; set; }
        public DbSet<Client> Clients { get; set; }

        public SPIDbContext(DbContextOptions<SPIDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlite("Data Source=spi.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FinantialProductFakeData.Init(3);

            //modelBuilder.Entity<FinantialProduct>().HasData(FinantialProductFakeData.FinantialProducts);
            //modelBuilder.Entity<Client>().HasData(FinantialProductFakeData.Clients);
            base.OnModelCreating(modelBuilder);
        }
    }
}