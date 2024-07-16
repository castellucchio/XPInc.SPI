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
    public class TransactionEFRepo : IRepo<Transaction>
    {
        private readonly SPIDbContext _dbContext;
        private readonly IMemoryCache _memoryCache;

        public TransactionEFRepo(SPIDbContext dbContext, IMemoryCache memoryCache)
        {
            _dbContext = dbContext;
            _memoryCache = memoryCache;
        }

        public async Task Add(Transaction item)
        {
            await _dbContext.Transactions.AddAsync(item);
        }

        public Task Delete(int id)
        {
            throw new InvalidOperationException();
        }

        public Task Edit(int id, Transaction item)
        {
            throw new InvalidOperationException();
        }

        public async Task<Transaction> Get(int id)
        {
            var transaction = await _dbContext.Transactions.FindAsync(id);
            if (transaction == null)
            {
                throw new ArgumentException($"Transação com ID {id} não encontrado.");
            }
            return transaction;
        }

        public async Task<IEnumerable<Transaction>> GetAll(int pageIndex = 1, int pageSize = 10)
        {
            pageIndex = pageIndex == 0 ? 1 : pageIndex;
            pageSize = pageSize == 0 ? 10 : pageSize;
            return await _dbContext.Transactions
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
