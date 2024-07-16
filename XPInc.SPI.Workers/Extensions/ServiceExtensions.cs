using Hangfire;
using System.Reflection;
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

            builder.Services.AddHangfireServer();
        }

        public static void ConfigureBackgroundJobs()
        {
            //Configurar background jobs
            RecurringJob.AddOrUpdate<EmailNotificationBackgroundJob>("EmailNotificationBackgroundJob", x => x.Execute(), Cron.Daily);
        }
    }
}
