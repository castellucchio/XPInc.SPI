using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using XPInc.SPI.Adapters.UseCases.Products;
using XPInc.SPI.Application.Mappings;
using XPInc.SPI.Application.UseCases.Products.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar interfaces e implementações
builder.Services.AddTransient<IFinantialProductService, FinantialProductService>();
builder.Services.AddTransient<IFinantialProductService, FinantialProductService>();
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<FinantialProductMappings>();
});
// Registrar serviços de infraestrutura (banco de dados)
//services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer("sua string de conexão"));

// Registrar os manipuladores de solicitação
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateFinantialProductRequestHandler).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
