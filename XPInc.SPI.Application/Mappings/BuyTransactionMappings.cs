using AutoMapper;
using XPInc.SPI.Application.UseCases.Investments.Requests;
using XPInc.SPI.Application.UseCases.Investments.Responses;
using XPInc.SPI.Entities.Enum;
using XPInc.SPI.Entities.Models;

namespace XPInc.SPI.Application.Mappings
{
    public class BuyTransactionMappings : Profile
    {
        public BuyTransactionMappings()
        {
            CreateMap<BuyFinantialProductRequest, Transaction>()
            .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId))
            .ForMember(dest => dest.FinantialProductId, opt => opt.MapFrom(src => src.FinancialProductId))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => TransactionType.Buy))
            .ForMember(dest => dest.TransactionDate, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => "Compra do produto financeiro " + src.FinancialProductId));

            CreateMap<Transaction, BuyFinantialProductResponse>();
            CreateMap<BuyFinantialProductRequest, BuyFinantialProductResponse>();                
        }
    }
}
