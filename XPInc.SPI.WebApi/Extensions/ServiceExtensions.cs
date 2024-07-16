using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using XPInc.SPI.Adapters.UseCases.Products;
using XPInc.SPI.Application.Mappings;
using XPInc.SPI.Application.UseCases.Investments;
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

            builder.Services.AddMemoryCache();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "SPI(Sistema de portfólio de Investimentos) API",
                    Description = "WebApi para gestão de portfólio de investimentos",
                    Contact = new OpenApiContact
                    {
                        Name = "Diego Amaro Castellucchio",
                        Url = new Uri("https://www.linkedin.com/in/diego-castellucchio/")
                    }
                });

                // using System.Reflection;
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            // Registrar interfaces e implementações
            builder.Services.AddScoped<IValidator<FinantialProduct>, FinantialProductValidator>();
            builder.Services.AddScoped<IBankStatementService, BankStatementService>();
            builder.Services.AddScoped<IFinantialProductService, FinantialProductService>();
            builder.Services.AddScoped<IInvestmentService, InvestmentService>();
            builder.Services.AddScoped<IRepo<FinantialProduct>, FinantialProductEFRepo>();
            builder.Services.AddScoped<IRepo<Client>,ClientEFRepo>();
            builder.Services.AddScoped<IClientRepo,ClientEFRepo>();
            builder.Services.AddScoped<IBankStatementRepo,TransactionEFRepo>();
            builder.Services.AddScoped<IRepo<Transaction>,TransactionEFRepo>();


            builder.Services.AddAutoMapper(config =>
            {
                config.AddProfile<FinantialProductMappings>();
                config.AddProfile<BuyTransactionMappings>();
                config.AddProfile<SellTransactionMappings>();
                config.AddProfile<BankStatementMappings>();
            });

            // Registrar serviços de infraestrutura (banco de dados)            
            builder.Services.AddDbContext<SPIDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SPI")));

            // Registrar os manipuladores de solicitação
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateFinantialProductRequestHandler).Assembly));

            builder.Services.AddScoped<UnitOfWork>();
        }
    }
}
