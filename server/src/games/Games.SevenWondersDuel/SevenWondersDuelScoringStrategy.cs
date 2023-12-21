using System.Text.Json;
using BGS.ApplicationCore.Games.CalculateScore;

namespace BGS.Games.SevenWondersDuel;

internal class SevenWondersDuelScoringStrategy : IGameScoringStrategy
{
    public int Calculate(JsonElement scoringData)
    {
        var model = scoringData.Deserialize<SevenWondersDuelScoringModel>();

        if (model.IsWonViaMilitarySupremacy || model.IsWonViaScientificSupremacy)
        {
            return 0;
        }

        return (int)(
            model.BlueBuildingsScore +
            model.GreenBuildingsScore +
            model.YellowBuildingsScore +
            model.PurpleBuildingsScore +
            model.WondersScore +
            model.ProgressScore +
            model.CoinsScore / 3.0 +
            model.MilitaryScore
        );
    }
}