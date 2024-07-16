using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPInc.SPI.Entities.Models;

namespace XPInc.SPI.Application.UseCases.Investments
{
    public interface IInvestmentService
    {
        Task<Transaction> BuyFinantialProduct(Transaction transaction);
        Task<Transaction> SellFinantialProduct(Transaction transaction);
    }
}
