using BGS.Api.Middleware;
using BGS.Api.ServiceInstallers.Extensions;
using BGS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "client_dist"),
    Args = args,
});

builder.Services.InstallServicesInAssembly(builder.Configuration);

var app = builder.Build();

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

app.UseSwagger();
app.UseSwaggerUI();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

await using var scope = app.Services.CreateAsyncScope();
await scope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.MigrateAsync();

await app.RunAsync();