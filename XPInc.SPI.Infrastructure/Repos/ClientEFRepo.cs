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
    public class ClientEFRepo : IClientRepo
    {
        private readonly SPIDbContext _dbContext;
        private readonly IMemoryCache _memoryCache;

        public ClientEFRepo(SPIDbContext dbContext, IMemoryCache memoryCache)
        {
            _dbContext = dbContext;
            _memoryCache = memoryCache;
        }

        public async Task Add(Client item)
        {
            await _dbContext.Clients.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var clientToDelete = await _dbContext.Clients.FindAsync(id);
            if (clientToDelete == null)
            {
                throw new ArgumentException($"Cliente com ID {id} não encontrado.");
            }

            _dbContext.Clients.Remove(clientToDelete);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Edit(int id, Client item)
        {
            var existingClient = await _dbContext.Clients.FindAsync(id);
            if (existingClient == null)
            {
                throw new ArgumentException($"Cliente com ID {id} não encontrado.");
            }

            existingClient.Name = item.Name;
            existingClient.Document = item.Document;
            existingClient.Account = item.Account;
            existingClient.BranchNumber = item.BranchNumber;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Client> Get(int id)
        {
            var client = await _dbContext.Clients.FindAsync(id);
            if (client == null)
            {
                throw new ArgumentException($"Cliente com ID {id} não encontrado.");
            }
            return client;
        }

        public async Task<IEnumerable<Client>> GetAll(int pageIndex = 1, int pageSize = 10)
        {
            pageIndex = pageIndex == 0 ? 1 : pageIndex;
            pageSize = pageSize == 0 ? 10 : pageSize;
            return await _dbContext.Clients
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetEspecificTransactionsByClient(int clientId, int productId)
        {
            return await _dbContext.Transactions
                .OrderBy(x => x.ClientId)
                .Where(t => t.FinantialProductId == productId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByClient(int clientId)
        {
            return await _dbContext.Transactions
                .OrderBy(x => x.ClientId)
                .ToListAsync();
        }
    }
}
