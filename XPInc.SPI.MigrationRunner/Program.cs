using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using XPInc.SPI.Infrastructure.DbContexts;

// Executável que aplica as migrations pendentes (Estrutura e carga inicial dos dados do SPI)

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var optionsBuilder = new DbContextOptionsBuilder<SPIDbContext>();
optionsBuilder.UseSqlServer(configuration.GetConnectionString("SPI"));

using var dbContext = new SPIDbContext(optionsBuilder.Options);


var migrations = dbContext.Database.GetPendingMigrations();
foreach(var migration in migrations)
{
    Console.WriteLine($"Applying migration: {migration}");
    dbContext.Database.Migrate();    
}

Console.WriteLine("Migrations applied successfully!");
Console.ReadLine();