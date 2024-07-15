using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using XPInc.SPI.Entities.Enum;
using XPInc.SPI.Entities.Models;

namespace XPInc.SPI.Infrastructure.Migrations.Seeds
{
    /// <summary>
    /// Example uses Faker[T]
    /// </summary>
    public static class SPIDbSeeder
    {
        public static List<FinantialProduct> FinantialProducts = new List<FinantialProduct>();
        public static List<Client> Clients = new List<Client>();
        public static void Init()
        {
            FinantialProducts.AddRange(
                new List<FinantialProduct>()
                {
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
                }
            );

            Clients.AddRange(
            new List<Client>()
            {
                new Client
                {
                    ClientId = 1,
                    Name = "Jhon Doe",
                    Document = "123.456.789-00",
                    Account = "12345-6",
                    BranchNumber = "7890"
                },
                new Client
                {
                    ClientId = 2,
                    Name = "Jane Smith",
                    Document = "987.654.321-00",
                    Account = "98765-4",
                    BranchNumber = "4321"
                }
            });
        }
    }
}
