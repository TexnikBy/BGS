using BGS.Api.Middleware;
using BGS.Api.ServiceInstallers.Extensions;
using BGS.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "client_dist"),
    Args = args,
});

builder.Services.InstallServicesInAssembly(builder.Configuration);
builder.Services.AddScoped<DbInitializer>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var dbInitializer = scope.ServiceProvider.GetRequiredService<DbInitializer>();
dbInitializer.Run();

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