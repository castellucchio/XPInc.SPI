using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using XPInc.SPI.Adapters.UseCases.Products;
using XPInc.SPI.Application.Mappings;
using XPInc.SPI.Application.UseCases.Products.Handlers;
using XPInc.SPI.Application.UseCases.Validations;
using XPInc.SPI.Entities.Models;
using XPInc.SPI.Infrastructure.DbContexts;
using XPInc.SPI.Infrastructure.Repos;

namespace XPInc.SPI.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterServices(this WebApplicationBuilder builder, IWebHostEnvironment env)
        {
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Registrar interfaces e implementações
            builder.Services.AddScoped<IValidator<FinantialProduct>, FinantialProductValidator>();

            builder.Services.AddScoped<IFinantialProductService, FinantialProductService>();
            builder.Services.AddScoped<IRepo<FinantialProduct>, FinantialProductEFRepo>();


            builder.Services.AddAutoMapper(config =>
            {
                config.AddProfile<FinantialProductMappings>();
            });

            // Registrar serviços de infraestrutura (banco de dados)            
            builder.Services.AddDbContext<SPIDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SPI")));

            // Registrar os manipuladores de solicitação
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateFinantialProductRequestHandler).Assembly));
        }
    }
}
