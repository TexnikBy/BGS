using System.Composition;
using Autofac;
using BGS.ApplicationCore.Games.CalculateScore;
using BGS.Games.Shared.Interfaces;

namespace BGS.Games.SevenWondersDuel;

[Export(typeof(IGameModule))]
public class SevenWondersDuelModule : IGameModule
{
    public void AddBoardGame(ContainerBuilder builder)
    {
        builder.RegisterType<SevenWondersDuelScoringStrategy>().Keyed<IGameScoringStrategy>(nameof(SevenWondersDuel));
    }
}