using BGS.Api.ServiceInstallers.Interfaces;
using Microsoft.OpenApi.Models;

namespace BGS.Api.ServiceInstallers;

internal class SwaggerInstaller : IServiceInstaller
{
    private const string SecurityDefinitionName = "Bearer";

    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "BGS API", Version = "v1" });
            options.AddSecurityDefinition(SecurityDefinitionName, new OpenApiSecurityScheme
            {
                Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
                Type = SecuritySchemeType.ApiKey,
                In = ParameterLocation.Header,
                Name = "Authorization",
            });
            options.AddSecurityRequirement(
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = SecurityDefinitionName,
                                Type = ReferenceType.SecurityScheme,
                            },
                        },
                        Array.Empty<string>()
                    },
                });
        });
    }
}