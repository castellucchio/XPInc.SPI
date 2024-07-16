using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace XPInc.SPI.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvestmentController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public InvestmentController(ILogger logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("buy")]
        public async Task<IActionResult> Buy([FromBody] BuyRequest request)
        {
            //// Validar requisição
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //// Consultar produto financeiro
            //var product = await _financialProductService.GetByIdAsync(request.ProductId);
            //if (product == null)
            //{
            //    return NotFound("Produto financeiro não encontrado");
            //}

            //// Validar saldo do cliente
            //if (request.Quantity * product.CurrentPrice > GetCustomerBalance())
            //{
            //    return BadRequest("Saldo insuficiente");
            //}

            //// Realizar compra
            //var transaction = await _transactionService.BuyAsync(request.ProductId, request.Quantity, product.CurrentPrice);

            //// Atualizar saldo do cliente
            //UpdateCustomerBalance(transaction.TotalAmount);

            // Retornar resultado
            return Ok();
        }

    }
}
