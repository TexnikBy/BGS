using System.Text.Json;
using BGS.ApplicationCore.Games.CalculateScore;

namespace BGS.Games.TyrantsOfTheUnderdark;

internal class TyrantsOfTheUnderdarkScoringStrategy : IGameScoringStrategy
{
    public int Calculate(JsonElement scoringData)
    {
        var model = scoringData.Deserialize<TyrantsOfTheUnderdarkScoringModel>();

        return model.ControlSitesScore +
            model.TotalControlSitesScore * 2 +
            model.TroopsTrophyHallScore +
            model.DeckValueScore +
            model.InnerCircleDeckValueScore +
            model.VictoryPointTokensScore;
    }
}