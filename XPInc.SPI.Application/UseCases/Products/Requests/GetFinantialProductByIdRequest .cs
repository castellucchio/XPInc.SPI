using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPInc.SPI.Application.UseCases.Products.Responses;

namespace XPInc.SPI.Application.UseCases.Products.Requests
{
    public class GetFinantialProductByIdRequest : IRequest<GetFinantialProductByIdResponse>
    {
        public int Id { get; set; }
    }
}
