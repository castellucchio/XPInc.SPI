using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPInc.SPI.Adapters.UseCases.Products;
using XPInc.SPI.Application.Exceptions;
using XPInc.SPI.Application.UseCases.Investments.Requests;
using XPInc.SPI.Application.UseCases.Investments.Responses;
using XPInc.SPI.Entities.Models;

namespace XPInc.SPI.Application.UseCases.Investments.Handlers
{
    public class BuyFinantialProductRequestHandler : IRequestHandler<BuyFinantialProductRequest, BuyFinantialProductResponse>
    {
        private readonly IInvestmentService _investmentService;
        private readonly IMapper _mapper;

        public BuyFinantialProductRequestHandler(IInvestmentService investmentService, IMapper mapper)
        {
            _investmentService = investmentService;
            _mapper = mapper;
        }

        public async Task<BuyFinantialProductResponse> Handle(BuyFinantialProductRequest request, CancellationToken cancellationToken)
        {
            var transaction = _mapper.Map<BuyFinantialProductRequest,Transaction>(request);
            var investment = await _investmentService.BuyFinantialProduct(transaction);
            
            return _mapper.Map<Transaction,BuyFinantialProductResponse>(transaction);
        }
    }
}
