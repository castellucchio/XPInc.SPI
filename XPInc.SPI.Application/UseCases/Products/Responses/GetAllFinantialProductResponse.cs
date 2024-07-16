using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPInc.SPI.Entities.Enum;
using XPInc.SPI.Entities.Models;

namespace XPInc.SPI.Application.UseCases.Products.Responses
{
    public class GetAllFinantialProductResponse
    {
        public IEnumerable<FinantialProduct> products { get; set; }
        public int CurrentPage { get; set; }
        public int TotalProducts { get; set; }
    }
}
