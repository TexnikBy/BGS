using Autofac;
using BGS.ApplicationCore.Games.Interfaces;
using BGS.ApplicationCore.Games.Validators;

namespace BGS.ApplicationCore;

public class AutofacCoreModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        RegisterValidators(builder);
    }
    
    private static void RegisterValidators(ContainerBuilder builder)
    {
        builder.RegisterType<GameDuplicationChecker>()
            .As<IGameDuplicationChecker>()
            .InstancePerLifetimeScope();
    }
}