using FluentValidation;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using XPInc.SPI.Adapters.UseCases.Products;
using XPInc.SPI.Application.Email;
using XPInc.SPI.Application.UseCases.Validations;
using XPInc.SPI.Entities.Models;
using XPInc.SPI.Infrastructure.DbContexts;
using XPInc.SPI.Infrastructure.Repos;
using XPInc.SPI.Workers.Workers;

namespace XPInc.SPI.Workers.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterServices(this WebApplicationBuilder builder, IWebHostEnvironment env)
        {

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddControllers();

            builder.Services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(builder.Configuration.GetConnectionString("SPI")));

            builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
            builder.Services.AddScoped<IValidator<FinantialProduct>, FinantialProductValidator>();
            builder.Services.AddScoped<IFinantialProductService, FinantialProductService>();
            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.AddScoped<IFinantialProductRepo, FinantialProductEFRepo>();
            builder.Services.AddScoped<IRepo<FinantialProduct>, FinantialProductEFRepo>();

            // Registrar serviços de infraestrutura (banco de dados)            
            builder.Services.AddDbContext<SPIDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SPI")));
            builder.Services.AddHangfireServer();
        }

        public static void ConfigureBackgroundJobs()
        {
            //Configurar background jobs
            RecurringJob.AddOrUpdate<EmailNotificationBackgroundJob>("EmailNotificationBackgroundJob", x => x.Execute(), Cron.Daily);
        }
    }
}
