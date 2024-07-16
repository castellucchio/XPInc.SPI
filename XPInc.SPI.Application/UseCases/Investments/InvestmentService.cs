using Azure.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPInc.SPI.Application.Exceptions;
using XPInc.SPI.Entities.Enum;
using XPInc.SPI.Entities.Models;
using XPInc.SPI.Infrastructure.Repos;

namespace XPInc.SPI.Application.UseCases.Investments
{
    public class InvestmentService : IInvestmentService
    {
        private readonly UnitOfWork _unitOfWork;

        public InvestmentService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Transaction> BuyFinantialProduct(Transaction transaction)
        {
            try
            {

                // Iniciar a transação
                await _unitOfWork.BeginTransaction();

                var product = await _unitOfWork.FinantialProducts.Get(transaction.FinantialProductId);
                if (product is null)
                {
                    throw new NotFoundException("Produto financeiro não encontrado");
                }

                var customer = await _unitOfWork.Clients.Get(transaction.ClientId);
                if (customer is null)
                {
                    throw new NotFoundException("Cliente não encontrado");
                }

                if (transaction.Quantity * product.Price > customer.TotalBalance)
                {
                    throw new InsuficientCashException("Saldo insuficiente");
                }


                await _unitOfWork.Transactions.Add(transaction);
                customer.TotalBalance -= transaction.Quantity * product.Price;

                // Confirmar a transação
                await _unitOfWork.Commit();

                return transaction;
            }
            catch (Exception ex)
            {
                await _unitOfWork.Rollback();
                throw;
            }
        }

        public async Task<Transaction> SellFinantialProduct(Transaction transaction)
        {
            try
            {
                //Inicia uma nova transação
                await _unitOfWork.BeginTransaction();

                var product = await _unitOfWork.FinantialProducts.Get(transaction.FinantialProductId);
                if (product is null)
                {
                    throw new NotFoundException("Produto financeiro não encontrado");
                }

                var customer = await _unitOfWork.Clients.Get(transaction.ClientId);
                if (customer is null)
                {
                    throw new NotFoundException("Cliente não encontrado");
                }

                var customerTransactions = await _unitOfWork.Clients.GetTransactionsByClient(transaction.ClientId);
                var qtd = await _unitOfWork.Clients.GetEspecificTransactionsByClient(transaction.ClientId, transaction.FinantialProductId);

                var hasPreviousPurchase = customerTransactions.Any(t => t.Type == TransactionType.Buy && t.FinantialProductId == transaction.FinantialProductId);

                if (!hasPreviousPurchase)
                {
                    throw new ValidationErrorException("O cliente não pode vender sem ter comprado antes");
                }

                // Verificar se o cliente já vendeu o mesmo produto antes
                var previousSales = customerTransactions.Count(t => t.Type == TransactionType.Sell && t.FinantialProductId == transaction.FinantialProductId);
                var previousBuys = customerTransactions.Count(t => t.Type == TransactionType.Buy && t.FinantialProductId == transaction.FinantialProductId);

                if (previousSales >= previousBuys)
                {
                    throw new InvalidOperationException("O cliente não pode vender o mesmo produto mais de uma vez");
                }

                await _unitOfWork.Transactions.Add(transaction);
                customer.TotalBalance += transaction.Quantity * product.Price;

                //Confirma a transação
                await _unitOfWork.Commit();

                return transaction;
            }
            catch (Exception ex)
            {
                await _unitOfWork.Rollback();
                throw;
            }            
        }
    }
}
