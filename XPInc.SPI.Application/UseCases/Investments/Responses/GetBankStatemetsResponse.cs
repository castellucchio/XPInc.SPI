using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPInc.SPI.Entities.Enum;
using XPInc.SPI.Entities.Models;

namespace XPInc.SPI.Application.UseCases.Investments.Responses
{
    public class GetBankStatemetResponse
    {
        public IEnumerable<Transaction> transactions { get; set; }
        public int CurrentPage { get; set; }
        public int TotalProducts { get; set; }
    }
}
