using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPInc.SPI.Entities.Models;
using XPInc.SPI.Infrastructure.DbContexts;

namespace XPInc.SPI.Infrastructure.Repos
{
    public class FinantialProductEFRepo : IFinantialProductRepo
    {
        private readonly SPIDbContext _dbContext;
        private readonly IMemoryCache _memoryCache;

        public FinantialProductEFRepo(SPIDbContext dbContext, IMemoryCache memoryCache) 
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        public async Task<IEnumerable<FinantialProduct>> GetAll(int pageIndex = 1, int pageSize = 10)
        {
            pageIndex = pageIndex == 0 ? 1 : pageIndex;
            pageSize = pageSize == 0 ? 10 : pageSize;
            return await _dbContext.FinantialProducts
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<FinantialProduct> Get(int id)
        {
            var cacheKey = $"FinantialProducts_{id}";
            if (_memoryCache.TryGetValue(cacheKey, out FinantialProduct cachedProduct))
            {
                return cachedProduct;
            }

            var product = await _dbContext.FinantialProducts.FindAsync(id);
            _memoryCache.Set(cacheKey, product, TimeSpan.FromMinutes(5));

            return product;
        }

        public async Task Add(FinantialProduct item)
        {
            await _dbContext.FinantialProducts.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Edit(int id, FinantialProduct item)
        {
            var cacheKey = $"FinantialProducts_{id}";

            var existingProduct = await _dbContext.FinantialProducts.FindAsync(id);
            if (existingProduct == null)
            {
                throw new ArgumentException($"Produto financeiro com ID {id} não encontrado.");
            }

            existingProduct.Name = item.Name;
            existingProduct.Description = item.Description;
            existingProduct.Type = item.Type;
            existingProduct.Price = item.Price;
            existingProduct.ExpireDate = item.ExpireDate;

            await _dbContext.SaveChangesAsync();
            _memoryCache.Remove(cacheKey);
        }

        public async Task Delete(int id)
        {
            var cacheKey = $"FinantialProducts_{id}";

            var productToDelete = await _dbContext.FinantialProducts.FindAsync(id);
            if (productToDelete == null)
            {
                throw new ArgumentException($"Produto financeiro com ID {id} não encontrado.");
            }

            _dbContext.FinantialProducts.Remove(productToDelete);
            await _dbContext.SaveChangesAsync();
            _memoryCache.Remove(cacheKey);
        }

        public async Task<IEnumerable<FinantialProduct>> GetExpiringProducts()
        {
            DateTime currentDate = DateTime.Now;           
            var oneWeekFromNow = currentDate.AddDays(7);

            return await _dbContext.FinantialProducts
                .Where(p => p.ExpireDate <= oneWeekFromNow)
                .OrderBy(p => p.ExpireDate)
                .ToListAsync();
        }
    }
}