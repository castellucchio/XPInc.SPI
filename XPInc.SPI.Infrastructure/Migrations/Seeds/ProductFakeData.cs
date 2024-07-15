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

        public static void Init(int count)
        {
            var productId = new Random().Next();
            var alphabet = Enumerable.Range('A', 'Z').Select(c => (char)c).ToArray();
            var postFaker = new Faker<FinantialProduct>()
                
                .StrictMode(true)
                .RuleFor(o => o.Id, new Random().Next())
                .RuleFor(p => p.Name, f => $"Ação da Empresa {f.PickRandom(alphabet)}")
                .RuleFor(p => p.ExpireDate, f => f.Date.Soon())
                .RuleFor(p => p.Description, f => $"Descrição da Empresa {f.PickRandom(alphabet)}")
                .RuleFor(p => p.Price, f => f.Finance.Amount())
                .RuleFor(u => u.Type, f => f.PickRandom<FinantialProductType>());



            var products = postFaker.Generate(count);

            FinantialProductFakeData.FinantialProducts.AddRange(products);
        }
    }
}
