using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPInc.SPI.Entities.Models;

namespace XPInc.SPI.Infrastructure.Repos
{
    public interface IClientRepo : IRepo<Client>
    {
        Task<IEnumerable<Transaction>> GetTransactionsByClient(int clientId);
        Task<IEnumerable<Transaction>> GetEspecificTransactionsByClient(int clientId, int productId);
    }
}
