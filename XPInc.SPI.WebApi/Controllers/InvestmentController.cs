using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using XPInc.SPI.Application.UseCases.Investments.Requests;

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

        [HttpPost("buy")]
        public async Task<IActionResult> Buy([FromBody] BuyFinantialProductRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("sell")]
        public async Task<IActionResult> Sell([FromBody] SellFinantialProductRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
