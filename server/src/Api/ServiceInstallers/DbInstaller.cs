using BGS.Api.ServiceInstallers.Interfaces;
using BGS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BGS.Api.ServiceInstallers;

internal class DbInstaller : IServiceInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connection).UseSnakeCaseNamingConvention());
    }
}