using System.Composition;
using Autofac;
using BGS.ApplicationCore.Games.CalculateScore;
using BGS.Games.Shared.Interfaces;

namespace BGS.Games.TyrantsOfTheUnderdark;

[Export(typeof(IGameModule))]
public class TyrantsOfTheUnderdarkModule : IGameModule
{
    public void AddBoardGame(ContainerBuilder builder)
    {
        builder
            .RegisterType<TyrantsOfTheUnderdarkScoringStrategy>()
            .Keyed<IGameScoringStrategy>(nameof(TyrantsOfTheUnderdark));
    }
}