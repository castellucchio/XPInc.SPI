using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPInc.SPI.Application.UseCases.Investments.Requests;
using XPInc.SPI.Entities.Models;

namespace XPInc.SPI.Application.UseCases.Investments
{
    public interface IBankStatementService
    {
        Task<IEnumerable<Transaction>> GetTransactions(GetBankStatemetRequest request);
    }
}
