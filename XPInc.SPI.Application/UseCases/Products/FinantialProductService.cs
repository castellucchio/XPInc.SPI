using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPInc.SPI.Application.Exceptions;
using XPInc.SPI.Application.UseCases.Validations;
using XPInc.SPI.Entities.Models;
using XPInc.SPI.Infrastructure.Repos;

namespace XPInc.SPI.Adapters.UseCases.Products
{
    public class FinantialProductService : IFinantialProductService
    {
        private readonly IValidator<FinantialProduct> _validator;
        private readonly IRepo<FinantialProduct> _repo;
       
        public FinantialProductService(IValidator<FinantialProduct> validator, IRepo<FinantialProduct> repo)
        {
            _repo = repo;
            _validator = validator;
        }

        public async Task CreateFinantialProduct(FinantialProduct product)
        {
            var validationResult = _validator.Validate(product);

            if (!validationResult.IsValid)
            {
                throw new ValidationErrorException("Ocorreram erros de validação: ",validationResult.Errors.Select(e => e.ErrorMessage));
            }

            await _repo.Add(product);            
        }

        public Task<FinantialProduct> GetFinantialProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<FinantialProduct>> GetFinantialProducts(int pageIndex = 1, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        public Task UpdateFinantialProduct(FinantialProduct product, int id)
        {
            throw new NotImplementedException();
        }
    }
}
