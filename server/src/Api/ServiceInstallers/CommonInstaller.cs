using Api.ServiceInstallers.Interfaces;

namespace Api.ServiceInstallers;

internal class CommonInstaller : IServiceInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddMvc();
    }
}