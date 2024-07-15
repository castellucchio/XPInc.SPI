using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPInc.SPI.Entities.Models;
using XPInc.SPI.Infrastructure.DbContexts;

namespace XPInc.SPI.Infrastructure.Repos
{
    public class FinantialProductEFRepo : IRepo<FinantialProduct>
    {
        private readonly SPIDbContext _dbContext;

        public FinantialProductEFRepo(SPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(FinantialProduct item)
        {
            await _dbContext.FinantialProducts.AddAsync(item);
        }

        public async Task Delete(int id)
        {
            var product = _dbContext.FinantialProducts.Where(fp => fp.Id == id).FirstOrDefault();
            _dbContext.FinantialProducts.Remove(product);

            await _dbContext.SaveChangesAsync();
        }

        public async Task Edit(int id, FinantialProduct item)
        {
            var product = await _dbContext.FinantialProducts.Where(p => p.Id == id).FirstAsync();

            product.Name = item.Name;
            product.Description = item.Description;
            product.Type = item.Type;
            product.ExpireDate = item.ExpireDate;
            product.Price = item.Price;
            
            _dbContext.Update(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<FinantialProduct> Get(int id)
        {
            var product = await _dbContext.FinantialProducts
                .AsNoTracking()
                .OrderBy(x => x.Id)
                .Where(p => p.Id == id)
                .FirstAsync();

            return product;
        }

        public async Task<IEnumerable<FinantialProduct>> GetAll(int pageIndex = 1, int pageSize = 10)
        {
            var products = await _dbContext.FinantialProducts.AsNoTracking()
                .OrderBy(x => x.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return products;
        }
    }
}
