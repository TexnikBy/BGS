using Autofac;
using BGS.ApplicationCore.Games.Constants;
using BGS.ApplicationCore.Games.Interfaces;

namespace BGS.Games.StoneAge;

public static class StoneAgeContainerBuilderExtensions
{
    public static ContainerBuilder AddStoneAge(this ContainerBuilder builder)
    {
        builder.RegisterType<StoneAgeScoringStrategy>().Keyed<IGameScoringStrategy>(GameKeys.StoneAge);

        return builder;
    }
}