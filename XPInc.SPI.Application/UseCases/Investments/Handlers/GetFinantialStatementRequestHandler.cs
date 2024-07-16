using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPInc.SPI.Application.UseCases.Investments.Requests;
using XPInc.SPI.Application.UseCases.Investments.Responses;
using XPInc.SPI.Application.UseCases.Products.Responses;
using XPInc.SPI.Entities.Models;

namespace XPInc.SPI.Application.UseCases.Investments.Handlers
{
    public class GetFinantialStatementRequestHandler : IRequestHandler<GetBankStatemetRequest, GetBankStatemetResponse>
    {
        private readonly IBankStatementService _bankStatementService;
        private readonly IMapper _mapper;

        public GetFinantialStatementRequestHandler(IBankStatementService bankStatementService, IMapper mapper)
        {
            _bankStatementService = bankStatementService;
            _mapper = mapper;
        }

        public async Task<GetBankStatemetResponse> Handle(GetBankStatemetRequest request, CancellationToken cancellationToken)
        {
            var bankStatement = await _bankStatementService.GetTransactions(request);
            var response = new GetBankStatemetResponse
            {
                transactions = _mapper.Map<IEnumerable<Transaction>>(bankStatement),
                CurrentPage = request.PageIndex,
                TotalProducts = bankStatement.Count()
            };

            return response;
        }
    }
}
