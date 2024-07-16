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
    public class UpdateFinantialProductRequestHandler : IRequestHandler<UpdateFinantialProductRequest, UpdateFinantialProductResponse>
    {
        private readonly IFinantialProductService _productService;
        private readonly IMapper _mapper;

        public UpdateFinantialProductRequestHandler(IFinantialProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<UpdateFinantialProductResponse> Handle(UpdateFinantialProductRequest request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<UpdateFinantialProductRequest, FinantialProduct>(request);
            await _productService.UpdateFinantialProduct(product,request.Id);

            return _mapper.Map<UpdateFinantialProductRequest, UpdateFinantialProductResponse>(request);
        }
    }
}
