using MediatR;
using Microsoft.AspNetCore.Mvc;
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

    [HttpPost]
    public async Task<ActionResult<CreateFinantialProductResponse>> CriarProduto([FromBody] CreateFinantialProductRequest request)
    {
        var response = await _mediator.Send(request);
        return CreatedAtAction(nameof(CriarProduto), response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateFinantialProductResponse>> AlterarProduto([FromBody] UpdateFinantialProductRequest request, [FromRoute] int id)
    {
        if (id != request.Id)
        {
            return BadRequest("Id do produto na requisição diferente do Id na rota.");
        }

        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
