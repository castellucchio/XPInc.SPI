using Azure.Core;
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

        public async Task<FinantialProduct> GetFinantialProductById(int id)
        {
            var product = await _repo.Get(id);

            if(product is null)
            {
                throw new NotFoundException("Produto não existe na base de dados");
            }

            return product;
        }

        public async Task<IEnumerable<FinantialProduct>> GetFinantialProducts(int pageIndex = 1, int pageSize = 10)
        {
            if (pageIndex <= 0)
            {
                throw new ValidationErrorException("A página atual da consulta deve ser >= 1");
            }

            var products = await _repo.GetAll(pageIndex, pageSize);

            return products;
        }

        public async Task UpdateFinantialProduct(FinantialProduct product, int id)
        {
            var validationResult = _validator.Validate(product);

            if (!validationResult.IsValid)
            {
                throw new ValidationErrorException("Ocorreram erros de validação: ", validationResult.Errors.Select(e => e.ErrorMessage));
            }

            await _repo.Edit(id,product);
        }
    }
}
