using FluentValidation;
using Microsoft.EntityFrameworkCore;
using XPInc.SPI.Adapters.UseCases.Products;
using XPInc.SPI.Application.Mappings;
using XPInc.SPI.Application.UseCases.Products.Handlers;
using XPInc.SPI.Application.UseCases.Validations;
using XPInc.SPI.Entities.Models;
using XPInc.SPI.Infrastructure.DbContexts;

namespace XPInc.SPI.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Registrar interfaces e implementações
            builder.Services.AddTransient<IFinantialProductService, FinantialProductService>();
            builder.Services.AddScoped<IValidator<FinantialProduct>, FinantialProductValidator>();

            builder.Services.AddAutoMapper(config =>
            {
                config.AddProfile<FinantialProductMappings>();
            });

            // Registrar serviços de infraestrutura (banco de dados)
            builder.Services.AddDbContext<SPIDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("FinanceiroDb")));

            // Registrar os manipuladores de solicitação
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateFinantialProductRequestHandler).Assembly));

        }
    }
}
