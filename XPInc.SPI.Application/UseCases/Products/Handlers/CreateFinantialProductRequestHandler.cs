using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPInc.SPI.Adapters.UseCases.Products;
using XPInc.SPI.Application.UseCases.Products.Responses;
using XPInc.SPI.Entities.Models;

namespace XPInc.SPI.Application.UseCases.Products.Handlers
{
    public class CreateFinantialProductRequestHandler : IRequestHandler<CreateFinantialProductRequest, CreateFinantialProductResponse>
    {
        private readonly IFinantialProductService  _productService;
        private readonly IMapper _mapper;

        public CreateFinantialProductRequestHandler(IFinantialProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<CreateFinantialProductResponse> Handle(CreateFinantialProductRequest request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<CreateFinantialProductRequest, FinantialProduct>(request);
            var result = await _productService.CreateFinantialProduct(product);

            return _mapper.Map<CreateFinantialProductRequest, CreateFinantialProductResponse>(request);
        }
    }
}
