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
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
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
            // Implemente a lógica para buscar um produto financeiro específico pelo ID
            return await _dbContext.FinantialProducts.FindAsync(id);
        }

        public async Task Add(FinantialProduct item)
        {
            // Implemente a lógica para adicionar um novo produto financeiro ao banco de dados
            await _dbContext.FinantialProducts.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Edit(int id, FinantialProduct item)
        {
            // Implemente a lógica para atualizar um produto financeiro existente no banco de dados
            var existingProduct = await _dbContext.FinantialProducts.FindAsync(id);
            if (existingProduct == null)
            {
                throw new ArgumentException($"Produto financeiro com ID {id} não encontrado.");
            }

            // Atualize as propriedades do produto existente com os valores de 'item'
            existingProduct.Name = item.Name;
            existingProduct.Description = item.Description;
            existingProduct.Type = item.Type;
            existingProduct.Price = item.Price;
            existingProduct.ExpireDate = item.ExpireDate;

            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            // Implemente a lógica para excluir um produto financeiro pelo ID
            var productToDelete = await _dbContext.FinantialProducts.FindAsync(id);
            if (productToDelete == null)
            {
                throw new ArgumentException($"Produto financeiro com ID {id} não encontrado.");
            }

            _dbContext.FinantialProducts.Remove(productToDelete);
            await _dbContext.SaveChangesAsync();
        }

    }
}