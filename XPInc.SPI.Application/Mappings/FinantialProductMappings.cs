using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPInc.SPI.Application.UseCases.Products.Responses;
using XPInc.SPI.Entities.Models;

namespace XPInc.SPI.Application.Mappings
{
    public class FinantialProductMappings : Profile
    {
        public FinantialProductMappings()
        {
            CreateMap<CreateFinantialProductRequest, FinantialProduct>();
            CreateMap<CreateFinantialProductRequest, CreateFinantialProductResponse>();
            CreateMap<UpdateFinantialProductRequest, FinantialProduct>();
            CreateMap<UpdateFinantialProductRequest, UpdateFinantialProductResponse>();
            CreateMap<FinantialProduct, GetFinantialProductByIdResponse>();
            CreateMap<FinantialProduct, GetAllFinantialProductResponse>()
            .ForMember(dest => dest.products, opt => opt.MapFrom(src => src));
        }
    }
}
