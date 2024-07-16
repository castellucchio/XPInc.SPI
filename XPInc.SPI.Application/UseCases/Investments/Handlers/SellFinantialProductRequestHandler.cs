using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPInc.SPI.Adapters.UseCases.Products;
using XPInc.SPI.Application.UseCases.Investments.Requests;
using XPInc.SPI.Application.UseCases.Investments.Responses;
using XPInc.SPI.Application.UseCases.Products.Responses;
using XPInc.SPI.Entities.Models;

namespace XPInc.SPI.Application.UseCases.Investments.Handlers
{
    public class SellFinantialProductRequestHandler : IRequestHandler<SellFinantialProductRequest,SellFinantialProductResponse>
    {
        private readonly IInvestmentService _investmentService;
        private readonly IMapper _mapper;

        public SellFinantialProductRequestHandler(IInvestmentService investmentService, IMapper mapper)
        {
            _investmentService = investmentService;
            _mapper = mapper;
        }

        public async Task<SellFinantialProductResponse> Handle(SellFinantialProductRequest request, CancellationToken cancellationToken)
        {
            var transaction = _mapper.Map<SellFinantialProductRequest, Transaction>(request);
            var investment = await _investmentService.SellFinantialProduct(transaction);

            return _mapper.Map<Transaction, SellFinantialProductResponse>(transaction);
        }
    }
}
