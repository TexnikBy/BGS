using BGS.Api.ServiceInstallers.Interfaces;

namespace BGS.Api.ServiceInstallers;

internal class CommonInstaller : IServiceInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMvc();
        services.AddOptions();
        services.AddControllers();
    }
}