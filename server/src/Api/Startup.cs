using Api.Middleware;
using Api.ServiceInstallers.Extensions;

namespace Api;

public class Startup
{
    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        Configuration = configuration;
        Environment = env;
    }

    private IConfiguration Configuration { get; }

    private IWebHostEnvironment Environment { get; }
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.InstallServicesInAssembly(Configuration);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseHsts();
            app.UseHttpsRedirection();
        }

        app.UseRouting();
        app.UseMiddleware<SpaMiddleware>();
        app.UseDefaultFiles();
        app.UseStaticFiles();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}