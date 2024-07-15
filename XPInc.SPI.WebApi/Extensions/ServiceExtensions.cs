using FluentValidation;
using XPInc.SPI.Adapters.UseCases.Products;
using XPInc.SPI.Application.Mappings;
using XPInc.SPI.Application.UseCases.Products.Handlers;
using XPInc.SPI.Application.UseCases.Validations;
using XPInc.SPI.Entities.Models;

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
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer("sua string de conexão"));

            // Registrar os manipuladores de solicitação
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateFinantialProductRequestHandler).Assembly));

        }
    }
}
