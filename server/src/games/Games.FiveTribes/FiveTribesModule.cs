using System.Composition;
using Autofac;
using BGS.ApplicationCore.Games.CalculateScore;
using BGS.Games.Shared.Interfaces;

namespace BGS.Games.FiveTribes;

[Export(typeof(IGameModule))]
public class FiveTribesModule : IGameModule
{
    public void AddBoardGame(ContainerBuilder builder)
    {
        builder.RegisterType<FiveTribesScoringStrategy>().Keyed<IGameScoringStrategy>(nameof(FiveTribes));
    }
}