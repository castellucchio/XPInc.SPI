using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPInc.SPI.Entities.Enum;

namespace XPInc.SPI.Application.UseCases.Products.Responses
{
    public class GetFinantialProductByIdResponse
    {
        public int Id { get; set; }
        /// <summary>
        /// O nome do produto (por exemplo, “Ação da Empresa X” ou “Título ABC”). 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Informações adicionais sobre o produto. 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// O tipo de produto (ações, títulos, fundos)
        /// </summary>
        public FinantialProductType Type { get; set; }

        /// <summary>
        /// O valor atual do produto no mercado. 
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Se aplicável (para títulos, por exemplo).
        /// </summary>
        public DateTime? ExpireDate { get; set; }
    }
}
