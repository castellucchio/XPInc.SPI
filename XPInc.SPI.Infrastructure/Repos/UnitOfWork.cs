using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPInc.SPI.Entities.Models;
using XPInc.SPI.Infrastructure.DbContexts;

namespace XPInc.SPI.Infrastructure.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _currentTransaction;
        private readonly SPIDbContext _dbContext;
        public IRepo<FinantialProduct> FinantialProducts { get; set; }
        public IRepo<Transaction> Transactions { get; set; }
        public IClientRepo Clients { get; set; }

        public UnitOfWork(SPIDbContext dbContext, IRepo<FinantialProduct> finantialProducts, IRepo<Transaction> transactions, IClientRepo clients)
        {
            _dbContext = dbContext;
            FinantialProducts = finantialProducts;
            Transactions = transactions;
            Clients = clients;
        }
               

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task BeginTransaction()
        {
            _currentTransaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
            await _currentTransaction?.CommitAsync();            
        }

        public async Task Rollback()
        {
            await _currentTransaction?.RollbackAsync();
        }
    }
}
