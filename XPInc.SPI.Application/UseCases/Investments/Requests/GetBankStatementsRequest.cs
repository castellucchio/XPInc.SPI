using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPInc.SPI.Application.UseCases.Investments.Responses;
using XPInc.SPI.Entities.Enum;

namespace XPInc.SPI.Application.UseCases.Investments.Requests
{
    public class GetBankStatemetRequest : IRequest<GetBankStatemetResponse>
    {
        public int ClientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TransactionType TransactionType { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
