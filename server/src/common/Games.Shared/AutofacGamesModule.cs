using System;
using System.Collections.Generic;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Autofac;
using BGS.Games.Shared.Interfaces;

namespace BGS.Games.Shared;

public class AutofacGamesModule : Autofac.Module
{
    private static readonly string ThisModuleName = typeof(AutofacGamesModule).Module.Name;
    private const string FileSearchPattern = $"{nameof(Games)}.*.dll";

    protected override void Load(ContainerBuilder builder)
    {
        var containerConfiguration = new ContainerConfiguration()
            .WithAssemblies(GetGamesAssemblies());

        using var compositionHost = containerConfiguration.CreateContainer();
        foreach (var boardGameModule in compositionHost.GetExports<IGameModule>())
        {
            Console.WriteLine(boardGameModule.GetType());
            boardGameModule.AddBoardGame(builder);
        }
    }
    
    private static IEnumerable<Assembly> GetGamesAssemblies() => Directory
        .GetFiles(AppDomain.CurrentDomain.BaseDirectory, FileSearchPattern)
        .Where(fileName => !fileName.EndsWith(ThisModuleName, StringComparison.InvariantCultureIgnoreCase))
        .Select(AssemblyLoadContext.Default.LoadFromAssemblyPath);
}