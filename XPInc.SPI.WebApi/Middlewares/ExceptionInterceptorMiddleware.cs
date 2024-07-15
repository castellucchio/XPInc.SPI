using Microsoft.AspNetCore.Http;
using XPInc.SPI.Application.Exceptions;

namespace XPInc.SPI.WebApi.Middlewares
{
    public class ExceptionInterceptorMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionInterceptorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationErrorException ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(new { Errors = ex.Errors.Select(e => new { Erro = e }) });
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new { Error = "Ocorreu um erro inesperado." });
            }
        }
    }
}
