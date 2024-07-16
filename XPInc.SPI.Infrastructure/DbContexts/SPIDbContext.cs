using Microsoft.EntityFrameworkCore;
using XPInc.SPI.Entities.Enum;
using XPInc.SPI.Entities.Models;
using XPInc.SPI.Infrastructure.Migrations.Seeds;

namespace XPInc.SPI.Infrastructure.DbContexts
{
    public class SPIDbContext : DbContext
    {
        public DbSet<FinantialProduct> FinantialProducts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public SPIDbContext(DbContextOptions<SPIDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=localhost\\MSSQLSERVER02;Database=SPI;Trusted_Connection=True;TrustServerCertificate=True;");
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FinantialProduct>().HasKey(p => p.Id);
            modelBuilder.Entity<Client>().HasKey(c => c.ClientId);
            modelBuilder.Entity<FinantialProduct>().HasIndex(t => new { t.Id });
            modelBuilder.Entity<Transaction>().HasIndex(t => new { t.ClientId, t.TransactionDate, t.Type });
            // Configuração da relação muitos-para-muitos entre Client e FinantialProduct (ações)
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Client)
                .WithMany(c => c.Transactions) // Propriedade de navegação em Client para as transações
                .HasForeignKey(t => t.ClientId);


            modelBuilder.Entity<Transaction>()                
                .HasOne(t => t.FinancialProduct)
                .WithMany() // Não precisamos de uma propriedade de navegação em FinancialProduct
                .HasForeignKey(t => t.FinantialProductId);

            // Seed FinantialProducts
            modelBuilder.Entity<FinantialProduct>().HasData(
                new FinantialProduct
                {
                    Id = 1,
                    Name = "Produto financeiro A",
                    Description = "Descrição do Produto A",
                    Type = FinantialProductType.Stock,
                    Price = 100.0m,
                    ExpireDate = DateTime.Now.AddMonths(1)
                },
                new FinantialProduct
                {
                    Id = 2,
                    Name = "Produto financeiro B",
                    Description = "Descrição do Produto B",
                    Type = FinantialProductType.Bond,
                    Price = 250.0m,
                    ExpireDate = DateTime.Now.AddMonths(2)
                },
                new FinantialProduct
                {
                    Id = 3,
                    Name = "Produto financeiro C",
                    Description = "Descrição do Produto C",
                    Type = FinantialProductType.Fund,
                    Price = 450.0m,
                    ExpireDate = DateTime.Now.AddMonths(3)
                }
            );
            // Seed Clients
            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    ClientId = 1,
                    Name = "Jhon Doe",
                    Document = "123.456.789-00",
                    Account = "12345-6",
                    BranchNumber = "7890",
                    TotalBalance = 5000000m
                },
                new Client
                {
                    ClientId = 2,
                    Name = "Jane Smith",
                    Document = "987.654.321-00",
                    Account = "98765-4",
                    BranchNumber = "4321",
                    TotalBalance = 1000000m
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}