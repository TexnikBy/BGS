using System.Composition;
using Autofac;
using BGS.ApplicationCore.Games.CalculateScore;
using BGS.Games.Shared.Interfaces;

namespace BGS.Games.BattleForRokugan;

[Export(typeof(IGameModule))]
public class BattleForRokuganModule : IGameModule
{
    public void AddBoardGame(ContainerBuilder builder)
    {
        builder.RegisterType<BattleForRokuganScoringStrategy>().Keyed<IGameScoringStrategy>(nameof(BattleForRokugan));
    }
}