using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPInc.SPI.Entities.Models;

namespace XPInc.SPI.Adapters.UseCases.Products
{
    public interface IFinantialProductService
    {
        Task CreateFinantialProduct(FinantialProduct product);
        Task UpdateFinantialProduct(FinantialProduct product, int id);
        Task<List<FinantialProduct>> GetFinantialProducts(int pageIndex = 1, int pageSize = 10);
        Task<FinantialProduct> GetFinantialProductById(int id);
    }
}
