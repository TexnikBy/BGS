using System.Text.Json;
using BGS.ApplicationCore.Games.CalculateScore;

namespace BGS.Games.TyrantsOfTheUnderdark;

internal class TyrantsOfTheUnderdarkScoringStrategy : IGameScoringStrategy
{
    public int Calculate(JsonElement scoringData)
    {
        var model = scoringData.Deserialize<TyrantsOfTheUnderdarkScoringModel>();

        return model.TrophyHall +
            model.Deck +
            model.InnerCircleDeck +
            model.Tokens +
            model.ControlSites +
            model.TotalControlSites;
    }
}