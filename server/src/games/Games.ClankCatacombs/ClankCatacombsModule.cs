using System.Composition;
using Autofac;
using BGS.ApplicationCore.Games.CalculateScore;
using BGS.Games.Shared.Interfaces;

namespace BGS.Games.ClankCatacombs;

[Export(typeof(IGameModule))]
public class ClankCatacombsModule : IGameModule
{
    public void AddBoardGame(ContainerBuilder builder)
    {
        builder.RegisterType<ClankCatacombsScoringStrategy>().Keyed<IGameScoringStrategy>(nameof(ClankCatacombs));
    }  
}