using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPInc.SPI.Application.UseCases.Investments.Responses;
using XPInc.SPI.Application.UseCases.Products.Responses;
using XPInc.SPI.Entities.Models;

namespace XPInc.SPI.Application.Mappings
{
    public class BankStatementMappings : Profile
    {
        public BankStatementMappings()
        {
            CreateMap<IEnumerable<Transaction>, GetBankStatemetResponse>()
            .ForMember(dest => dest.transactions, opt => opt.MapFrom(src => src));
        }
    }
}
