using Autofac;
using BGS.ApplicationCore.Interfaces;
using BGS.ApplicationCore.Validators;

namespace BGS.ApplicationCore;

public class AutofacCoreModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        RegisterValidators(builder);
    }
    
    private static void RegisterValidators(ContainerBuilder builder)
    {
        builder.RegisterType<GameNameDuplicationsChecker>()
            .As<IGameNameDuplicationsChecker>()
            .InstancePerLifetimeScope();
    }
}