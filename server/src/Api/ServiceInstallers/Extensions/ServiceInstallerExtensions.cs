using Api.ServiceInstallers.Interfaces;

namespace Api.ServiceInstallers.Extensions;

internal static class ServiceInstallerExtensions
{
    public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration) =>
        typeof(Startup).Assembly.DefinedTypes
            .Where(type => typeof(IServiceInstaller).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
            .Select(Activator.CreateInstance).Cast<IServiceInstaller>()
            .ToList()
            .ForEach(installer => installer.InstallServices(services, configuration));
}