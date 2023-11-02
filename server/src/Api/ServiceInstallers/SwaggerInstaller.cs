using BGS.Api.ServiceInstallers.Interfaces;
using Microsoft.OpenApi.Models;

namespace BGS.Api.ServiceInstallers;

internal class SwaggerInstaller : IServiceInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "BGS API", Version = "v1" });
        });
    }
}