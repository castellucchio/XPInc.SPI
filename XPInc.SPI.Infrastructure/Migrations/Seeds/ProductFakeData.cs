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
    public static class FinantialProductFakeData
    {
        public static List<FinantialProduct> FinantialProducts = new List<FinantialProduct>();
        public static List<Client> Clients = new List<Client>();
        public static void Init(int count)
        {
            int currentProductId = 1; // Initialize a static counter
            int currentClientId = 1; // Initialize a static counter

            var productsFaker = new Faker<FinantialProduct>()
              .StrictMode(true)
              .RuleFor(p => p.Id, currentProductId++) // Unique ID using Guid
              .RuleFor(p => p.Name, f => $"Ação da Empresa")
              .RuleFor(p => p.ExpireDate, f => f.Date.Soon())
              .RuleFor(p => p.Description, f => $"Descrição da Empresa")
              .RuleFor(p => p.Price, f => f.Finance.Amount())
              .RuleFor(u => u.Type, f => f.PickRandom<FinantialProductType>());

            var clientsFaker = new Faker<Client>()
              .StrictMode(true)
              .RuleFor(c => c.ClientId, currentClientId++) // Unique ID using Guid
              .RuleFor(p => p.Name, f => f.Name.FullName())
              .RuleFor(p => p.Account, new Bogus.Randomizer().Replace("####-####"))
              .RuleFor(p => p.BranchNumber, "0001")
              .RuleFor(p => p.Document, f => new Bogus.Randomizer().Replace("###-##-####"));

            var products = productsFaker.Generate(count);
            var clients = clientsFaker.Generate(count);

            FinantialProductFakeData.FinantialProducts.AddRange(products);            
            FinantialProductFakeData.Clients.AddRange(clients);
        }
    }
}
