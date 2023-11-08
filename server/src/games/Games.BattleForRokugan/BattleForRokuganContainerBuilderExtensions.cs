using Autofac;
using BGS.ApplicationCore.Games.Constants;
using BGS.ApplicationCore.Games.Interfaces;

namespace BGS.Games.BattleForRokugan;

public static class BattleForRokuganContainerBuilderExtensions
{
    public static ContainerBuilder AddBattleForRokugan(this ContainerBuilder builder)
    {
        builder.RegisterType<BattleForRokuganScoringStrategy>().Keyed<IGameScoringStrategy>(GameKeys.BattleForRokugan);

        return builder;
    }
}