using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPInc.SPI.Application.UseCases.Investments.Responses
{
    public class BuyFinantialProductResponse
    {
        /// <summary>
        /// ID do cliente que realizou a venda
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// ID do produto financeiro que o cliente vendeu
        /// </summary>
        public int FinancialProductId { get; set; }

        /// <summary>
        /// Quantidade do produto financeiro que o cliente vendeu
        /// </summary>
        public int Quantity { get; set; }
    }
}
