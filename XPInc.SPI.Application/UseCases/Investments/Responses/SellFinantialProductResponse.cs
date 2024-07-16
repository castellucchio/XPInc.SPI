using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPInc.SPI.Application.UseCases.Investments.Responses
{
    public class SellFinantialProductResponse
    {
        /// <summary>
        /// ID do cliente que realizou a compra
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// ID do produto financeiro que o cliente comprou
        /// </summary>
        public int FinancialProductId { get; set; }

        /// <summary>
        /// Quantidade do produto financeiro que o cliente comprou
        /// </summary>
        public int Quantity { get; set; }
    }
}
