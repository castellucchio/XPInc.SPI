using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPInc.SPI.Adapters.UseCases.Products;
using XPInc.SPI.Application.UseCases.Products.Requests;
using XPInc.SPI.Application.UseCases.Products.Responses;
using XPInc.SPI.Entities.Models;

namespace XPInc.SPI.Application.UseCases.Products.Handlers
{
    public class GetFinantialProductByIdRequestHandler : IRequestHandler<GetFinantialProductByIdRequest, GetFinantialProductByIdResponse>
    {
        private readonly IFinantialProductService _productService;
        private readonly IMapper _mapper;

        public GetFinantialProductByIdRequestHandler(IFinantialProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<GetFinantialProductByIdResponse> Handle(GetFinantialProductByIdRequest request, CancellationToken cancellationToken)
        {
            var product = await _productService.GetFinantialProductById(request.Id);
            return _mapper.Map<FinantialProduct, GetFinantialProductByIdResponse>(product);
        }
    }
}
