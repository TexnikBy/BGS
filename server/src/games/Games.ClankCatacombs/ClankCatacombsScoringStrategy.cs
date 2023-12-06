using System.Text.Json;
using BGS.ApplicationCore.Games.CalculateScore;

namespace BGS.Games.ClankCatacombs;

internal class ClankCatacombsScoringStrategy : IGameScoringStrategy
{
    public int Calculate(JsonElement scoringData)
    {
        var model = scoringData.Deserialize<ClankCatacombsScoringModel>();

        if (!model.isEscapedFromDepths)
        {
            return 0;
        }

        return model.ArtefactsScore +
            model.AllTokensScore +
            model.GoldCoinsScore +
            model.DeckValueScore;
    }
}