using Autofac;
using Autofac.Extensions.DependencyInjection;
using BGS.Api.Middleware;
using BGS.Api.ServiceInstallers.Extensions;
using BGS.Games;
using BGS.Infrastructure;
using BGS.Infrastructure.Data;
using BGS.UseCases;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "client_dist"),
    Args = args,
});

builder.Configuration.AddEnvironmentVariables();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new AutofacGamesModule());
    containerBuilder.RegisterModule(new AutofacUseCasesModule());
    containerBuilder.RegisterModule(new AutofacInfrastructureModule());
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

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

await app.Services.GetService<DatabaseSetup>().SetupAsync();
await app.RunAsync();