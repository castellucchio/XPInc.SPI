using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using XPInc.SPI.Application.UseCases.Investments.Requests;
using XPInc.SPI.Entities.Enum;

namespace XPInc.SPI.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvestmentController : ControllerBase
    {
        private readonly ILogger<InvestmentController> _logger;
        private readonly IMediator _mediator;

        public InvestmentController(ILogger<InvestmentController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Permite a compra de um produto financeiro por um cliente
        /// </summary>
        /// <param name="request">Objeto de requisição com os dados da negociação</param>
        /// <returns>Uma negociação de compra</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /Investment/buy
        ///     {
        ///       "clientId": 1,
        ///       "financialProductId": 1,
        ///       "quantity": 1
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Retorna a negociação de compra feita</response>
        /// <response code="400">Caso o objeto seja nulo</response>
        [HttpPost("buy")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Buy([FromBody] BuyFinantialProductRequest request)
        {
            var response = await _mediator.Send(request);
            return CreatedAtAction(nameof(Buy), response);
        }

        /// <summary>
        /// Permite a venda de um produto financeiro por um cliente
        /// </summary>
        /// <param name="request">Objeto de requisição com os dados da negociação</param>
        /// <returns>Uma negociação de venda</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /Investment/sell
        ///     {
        ///       "clientId": 1,
        ///       "financialProductId": 1,
        ///       "quantity": 1
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Retorna a negociação de venda feita</response>
        /// <response code="400">Caso o objeto seja nulo</response>
        [HttpPost("sell")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Sell([FromBody] SellFinantialProductRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// Permite a consulta de extrato de um determinado cliente
        /// </summary>
        /// <param name="clientId">Identificador do cliente no sistema SPI</param>
        /// <param name="datainicio">Filtro de data inicial a ser considerada no extrato</param>
        /// <param name="datafim">Filtro de data final a ser considerada no extrato</param>
        /// <param name="tipoNegociacao">Tipo de negociação a ser considerada no extrato (Compra/Venda)</param>
        /// <returns>Uma negociação de venda</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /Investment?clientId={clientId} datainicio={dataInicio} datafim={dataFim} tipoNegociacao={tipoNegociacao}
        ///     {
        ///       "clientId": 1,
        ///       "financialProductId": 1,
        ///       "quantity": 1
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Retorna a negociação de venda feita</response>
        /// <response code="400">Caso o objeto seja nulo</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int clientId, DateTime datainicio, DateTime datafim, TransactionType tipoNegociacao, int pageIndex = 1, int pageSize = 10)
        {
            var response = await _mediator.Send(new GetBankStatemetRequest { ClientId = clientId, StartDate = datainicio, EndDate = datafim, TransactionType = tipoNegociacao, PageIndex = pageIndex, PageSize = pageSize});
            return Ok(response);
        }
    }
}
