using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPInc.SPI.Application.UseCases.Investments.Responses;

namespace XPInc.SPI.Application.UseCases.Investments.Requests
{
    public class BuyFinantialProductRequest : IRequest<BuyFinantialProductResponse>
    {
        /// <summary>
        /// ID do cliente que deseja realizar a compra
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// ID do produto financeiro que o cliente deseja comprar
        /// </summary>
        public int FinancialProductId { get; set; }

        /// <summary>
        /// Quantidade do produto financeiro que o cliente deseja comprar
        /// </summary>
        public int Quantity { get; set; }
    }
}
