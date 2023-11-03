using System.Reflection;
using Autofac;
using BGS.Infrastructure.Data;
using BGS.SharedKernel;
using BGS.UseCases;
using MediatR;

namespace BGS.Infrastructure;

public class AutofacInfrastructureModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        RegisterMediatR(builder);
        RegisterEntityFrameworkCore(builder);

        builder.RegisterType<DatabaseSetup>()
            .AsSelf()
            .InstancePerLifetimeScope();
    }

    private static void RegisterMediatR(ContainerBuilder builder)
    {
        builder.RegisterType<Mediator>()
            .As<IMediator>()
            .InstancePerLifetimeScope();

        var useCasesAssembly = Assembly.GetAssembly(typeof(AutofacUseCasesModule));
        if (useCasesAssembly != null)
        {
            builder.RegisterAssemblyTypes(useCasesAssembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>))
                .AsImplementedInterfaces();
        }
    }
    
    private static void RegisterEntityFrameworkCore(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(EntityFrameworkCoreRepository<>))
            .As(typeof(IRepository<>))
            .InstancePerLifetimeScope();
    }
}