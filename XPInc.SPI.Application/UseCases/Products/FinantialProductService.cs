using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPInc.SPI.Entities.Models;

namespace XPInc.SPI.Adapters.UseCases.Products
{
    public class FinantialProductService : IFinantialProductService
    {
        public Task<int> CreateFinantialProduct(FinantialProduct product)
        {
            throw new NotImplementedException();
        }

        public Task<FinantialProduct> GetFinantialProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<FinantialProduct>> GetFinantialProducts(int pageIndex = 1, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateFinantialProduct(FinantialProduct product, int id)
        {
            throw new NotImplementedException();
        }
    }
}
