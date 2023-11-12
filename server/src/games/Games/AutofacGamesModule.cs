using Autofac;
using BGS.Games.BattleForRokugan;
using BGS.Games.StoneAge;

namespace BGS.Games;

public class AutofacGamesModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder
            .AddStoneAge()
            .AddBattleForRokugan();
    }
}