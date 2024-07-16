using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPInc.SPI.Application.UseCases.Products.Responses;

namespace XPInc.SPI.Application.UseCases.Products.Requests
{
    public class GetAllFinantialProductRequest : IRequest<GetAllFinantialProductResponse>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
