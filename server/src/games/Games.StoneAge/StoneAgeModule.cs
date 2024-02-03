using System.Composition;
using Autofac;
using BGS.ApplicationCore.Games.CalculateScore;
using BGS.Games.Shared.Interfaces;

namespace BGS.Games.StoneAge;

[Export(typeof(IGameModule))]
public class StoneAgeModule : IGameModule
{
    public void AddBoardGame(ContainerBuilder builder)
    {
        builder.RegisterType<StoneAgeCalculator>().Keyed<IGameCalculator>("stone-age");
    }
}