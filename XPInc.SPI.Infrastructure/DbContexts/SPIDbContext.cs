
using Bogus;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using XPInc.SPI.Entities.Enum;
using XPInc.SPI.Entities.Models;
using XPInc.SPI.Infrastructure.Migrations.Seeds;

namespace XPInc.SPI.Infrastructure.DbContexts
{
    public class SPIDbContext : DbContext
    {
        public DbSet<FinantialProduct> FinantialProducts { get; set; }
        //public SPIDbContext(DbContextOptions<SPIDbContext> options) : base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Source=financeiro.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            FinantialProductFakeData.Init(15);

            modelBuilder.Entity<FinantialProduct>().HasData(FinantialProductFakeData.FinantialProducts);            
        }
    }
}