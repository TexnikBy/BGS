using BGS.Api.Middleware;
using BGS.Api.ServiceInstallers.Extensions;
using BGS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "client_dist"),
    Args = args,
});

builder.Configuration.AddJsonFile("appsettings.json", false, true);
builder.Configuration.AddJsonFile("appsettings.Personal.json", true, true);

builder.Services.InstallServicesInAssembly(builder.Configuration);

var app = builder.Build();

await using var scope = app.Services.CreateAsyncScope();
await scope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.MigrateAsync();
await app.RunAsync();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseMiddleware<SpaMiddleware>();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();