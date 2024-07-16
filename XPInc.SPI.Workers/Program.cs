using Hangfire;
using XPInc.SPI.Workers.Extensions;
using XPInc.SPI.Workers.Workers;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices(builder.Environment);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseHangfireDashboard();
app.UseRouting();

app.UseAuthorization();
ServiceExtensions.ConfigureBackgroundJobs();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHangfireDashboard();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=hangfire}/{action=Index}/{id?}");

app.Run();
