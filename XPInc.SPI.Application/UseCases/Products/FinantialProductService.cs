using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPInc.SPI.Application.Exceptions;
using XPInc.SPI.Application.UseCases.Validations;
using XPInc.SPI.Entities.Models;

namespace XPInc.SPI.Adapters.UseCases.Products
{
    public class FinantialProductService : IFinantialProductService
    {
        private readonly IValidator<FinantialProduct> _validator;

        public FinantialProductService(IValidator<FinantialProduct> validator)
        {
            _validator = validator;
        }

        public Task<int> CreateFinantialProduct(FinantialProduct product)
        {
            var validationResult = _validator.Validate(product);

            if (!validationResult.IsValid)
            {
                throw new ValidationErrorException("Ocorreram erros de validação: ",validationResult.Errors.Select(e => e.ErrorMessage));
            }

            throw new Exception();
        }

        public Task<FinantialProduct> GetFinantialProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<FinantialProduct>> GetFinantialProducts(int pageIndex = 1, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateFinantialProduct(FinantialProduct product, int id)
        {
            throw new NotImplementedException();
        }
    }
}
