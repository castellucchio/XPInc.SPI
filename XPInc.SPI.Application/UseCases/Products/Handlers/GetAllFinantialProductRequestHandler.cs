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
    public class GetAllFinantialProductRequestHandler : IRequestHandler<GetAllFinantialProductRequest, GetAllFinantialProductResponse>
    {
        private readonly IFinantialProductService _productService;
        private readonly IMapper _mapper;

        public GetAllFinantialProductRequestHandler(IFinantialProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<GetAllFinantialProductResponse> Handle(GetAllFinantialProductRequest request, CancellationToken cancellationToken)
        {
            var products = await _productService.GetFinantialProducts(request.PageIndex, request.PageSize);

            // Mapeie para GetAllFinantialProductResponse
            var response = new GetAllFinantialProductResponse
            {
                products = _mapper.Map<IEnumerable<FinantialProduct>>(products),
                CurrentPage = ++request.PageIndex,
                TotalProducts = products.Count()
            };
            return response;
        }
    }
}
