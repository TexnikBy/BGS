using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using Autofac;
using BGS.ApplicationCore.Entities;
using BGS.ApplicationCore.Identity.Interfaces;
using BGS.Infrastructure.Data;
using BGS.Infrastructure.FileStorages;
using BGS.Infrastructure.FileStorages.Supabase;
using BGS.Infrastructure.FileStorages.System;
using BGS.Infrastructure.Identity;
using BGS.Infrastructure.Identity.Interfaces;
using BGS.SharedKernel;
using BGS.SharedKernel.DependencyInjection;
using BGS.UseCases;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BGS.Infrastructure;

public class AutofacInfrastructureModule(IConfiguration configuration) : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        RegisterMediatR(builder);
        AddJwtAuthentication(builder);
        RegisterFileStorages(builder);
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

    private static void AddJwtAuthentication(ContainerBuilder builder)
    {
        builder.RegisterType<AccessTokenGenerator>()
            .As<IAccessTokenGenerator>()
            .InstancePerLifetimeScope();
        builder.RegisterType<LoginService>()
            .As<ILoginService>()
            .InstancePerLifetimeScope();
        builder.RegisterType<UserClaimsProvider>()
            .As<IUserClaimsProvider>()
            .InstancePerLifetimeScope();
        builder.RegisterType<UserCredentialsValidator>()
            .As<IUserCredentialsValidator>()
            .InstancePerLifetimeScope();
        
        builder.RegisterType<JwtSecurityTokenHandler>()
            .As<SecurityTokenHandler>();
        builder.RegisterType<UserStore>()
            .As<IUserStore<User>>()
            .InstancePerLifetimeScope();
    }

    private void RegisterFileStorages(ContainerBuilder builder)
    {
        builder.Configure<FileStorageSettings>(configuration);
        builder.Configure<SystemStorageSettings>(configuration);
        builder.Configure<SupabaseStorageSettings>(configuration);
        builder.RegisterType<FileStorageFactory>()
            .As<IFileStorageFactory>()
            .InstancePerLifetimeScope();
        builder.Register(context => context.Resolve<IFileStorageFactory>().Create())
            .InstancePerLifetimeScope();
    }
    
    private static void RegisterEntityFrameworkCore(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(EntityFrameworkCoreRepository<>))
            .As(typeof(IRepository<>))
            .InstancePerLifetimeScope();
    }
}