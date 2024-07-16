using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using XPInc.SPI.Application.UseCases.Products.Requests;
using XPInc.SPI.Application.UseCases.Products.Responses;

namespace XPInc.SPI.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FinantialProductController : ControllerBase
{
    
    private readonly ILogger<FinantialProductController> _logger;
    private readonly IMediator _mediator;

    public FinantialProductController(ILogger<FinantialProductController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    /// <summary>
    /// Cria um produto financeiro no sistema SPI
    /// </summary>
    /// <param name="request">Objeto de requisi��o com os dados do produto financeiro a ser criado</param>
    /// <returns>Um produto financeiro recentemente criado</returns>
    /// <remarks>
    /// Exemplo de requisi��o:
    ///
    ///     POST /FinantialProduct
    ///     {
    ///       "id": 0,
    ///       "name": "Produto Financeiro A",
    ///       "description": "Descri��o do Produto A",
    ///       "type": 3,
    ///       "price": 52.55
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Retorna o produto financeiro rec�m criado</response>
    /// <response code="400">Caso o objeto seja nulo</response>

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreateFinantialProductResponse>> PostFinantialProduct([FromBody] CreateFinantialProductRequest request)
    {
        var response = await _mediator.Send(request);
        return CreatedAtAction(nameof(PostFinantialProduct), response);
    }

    /// <summary>
    /// Atualiza um produto financeiro no sistema SPI
    /// </summary>
    /// <param name="request">Objeto de requisi��o com os dados do produto financeiro a ser atualizado</param>
    /// <returns>Um produto financeiro recentemente criado</returns>
    /// <remarks>
    /// Exemplo de requisi��o:
    ///
    ///     PUT /FinantialProduct
    ///     {
    ///       "id": 0,
    ///       "name": "Produto Financeiro A",
    ///       "description": "Descri��o do Produto A",
    ///       "type": 3,
    ///       "price": 52.55
    ///     }
    ///
    /// </remarks>
    /// <response code="200">Retorna o produto financeiro rec�m atualizado</response>
    /// <response code="400">Caso o objeto seja nulo</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UpdateFinantialProductResponse>> UpdateFinantialProduct([FromBody] UpdateFinantialProductRequest request, [FromRoute] int id)
    {
        request.Id = id;
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    /// <summary>
    /// Consulta um produto financeiro no sistema SPI atrav�s de Identificador interno
    /// </summary>
    /// <param name="id">Identificador do produto financeiro no sistema SPI</param>
    /// <returns>Um produto financeiro encontrado</returns>
    /// <remarks>
    /// Exemplo de requisi��o:
    ///     GET /{id}
    /// </remarks>
    /// <response code="200">Retorna um produto encontrado</response>
    /// <response code="404">Caso o produto n�o exista no sistema SPI</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetFinantialProductByIdResponse>> FinantialProductById([FromRoute] int id)
    {
        var request = new GetFinantialProductByIdRequest { Id = id };
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    /// <summary>
    /// Consulta uma lista de produtos financeiros no sistema SPI
    /// </summary>
    /// <param name="pageIndex">P�gina atual para pagina��o</param>
    /// <param name="pageSize">N�mero de itens a serem retornados em uma �nica consulta</param>
    /// <returns>Uma lista de produtos financeiros encontrados</returns>
    /// <remarks>
    /// Exemplo de requisi��o:
    ///     GET /pageIndex={pageIndex} e pageSize={pageSize}
    /// </remarks>
    /// <response code="200">Retorna uma lista de produtos financeiros no sistema SPI</response>
    /// <response code="404">Caso nenhum produto seja encontrado no sistema SPI</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetAllFinantialProductResponse>> GetAll([Required] int pageIndex, [Required] int pageSize)
    {
        var response = await _mediator.Send(new GetAllFinantialProductRequest { PageIndex = pageIndex, PageSize = pageSize });
        return Ok(response);
    }
}
