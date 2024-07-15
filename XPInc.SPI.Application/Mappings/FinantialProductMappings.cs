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
            //var product = _mapper.Map<CreateFinantialProductRequest, FinantialProduct>(request);
            //var result = await _productService.CreateFinantialProduct(product);

            //return _mapper.Map<CreateFinantialProductRequest, CreateFinantialProductResponse>(request);
            CreateMap<CreateFinantialProductRequest, FinantialProduct>();
            CreateMap<CreateFinantialProductRequest, CreateFinantialProductResponse>();
            // Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)
        }
    }
}
