using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BGS.SharedKernel.DependencyInjection;

public static class OptionsContainerBuilderExtensions
{
    public static void Configure<TOptions>(this ContainerBuilder builder, IConfiguration configuration)
        where TOptions : class
    {
        var config = configuration.GetSection(typeof(TOptions).Name);
        
        builder.Register(_ => new ConfigurationChangeTokenSource<TOptions>(Options.DefaultName, config))
            .As<IOptionsChangeTokenSource<TOptions>>()
            .SingleInstance();
        builder.Register(_ => new NamedConfigureFromConfigurationOptions<TOptions>(Options.DefaultName, config, _ => { }))
            .As<IConfigureOptions<TOptions>>()
            .SingleInstance();
    }
}