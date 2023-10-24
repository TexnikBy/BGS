namespace BGS.Api.ServiceInstallers.Interfaces;

internal interface IServiceInstaller
{
    void InstallServices(IServiceCollection services, IConfiguration configuration);
}