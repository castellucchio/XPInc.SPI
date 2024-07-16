using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPInc.SPI.Application.Exceptions;
using XPInc.SPI.Application.UseCases.Investments.Requests;
using XPInc.SPI.Entities.Models;
using XPInc.SPI.Infrastructure.DbContexts;
using XPInc.SPI.Infrastructure.Repos;

namespace XPInc.SPI.Application.UseCases.Investments
{
    public class BankStatementService : IBankStatementService
    {
        private readonly IBankStatementRepo _transactionRepo;

        public BankStatementService(IBankStatementRepo transactionRepo)
        {
            _transactionRepo = transactionRepo;
        }

        public async Task<IEnumerable<Transaction>> GetTransactions(GetBankStatemetRequest request)
        {
            if(request.PageIndex <= 0)
            {
                throw new ValidationErrorException("A página atual da consulta deve ser >= 1");
            }

            var transactions = await _transactionRepo.GetClientBankStatement(clientId: request.ClientId, startDate: request.StartDate, endDate: request.EndDate, type: request.TransactionType, pageIndex: request.PageIndex, pageSize: request.PageSize);
            return transactions;
        }
    }
}
