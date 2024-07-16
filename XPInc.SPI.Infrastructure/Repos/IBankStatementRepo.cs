using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPInc.SPI.Entities.Enum;
using XPInc.SPI.Entities.Models;

namespace XPInc.SPI.Infrastructure.Repos
{
    public interface IBankStatementRepo : IRepo<Transaction>
    {
        Task<IEnumerable<Transaction>> GetClientBankStatement(int clientId, DateTime startDate, DateTime endDate, TransactionType type, int pageIndex = 1, int pageSize = 10);
    }
}
