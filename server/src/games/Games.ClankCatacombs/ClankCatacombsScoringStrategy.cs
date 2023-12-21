using System.Text.Json;
using BGS.ApplicationCore.Games.CalculateScore;

namespace BGS.Games.ClankCatacombs;

internal class ClankCatacombsScoringStrategy : IGameScoringStrategy
{
    public int Calculate(JsonElement scoringData)
    {
        var model = scoringData.Deserialize<ClankCatacombsScoringModel>();

        if (!model.IsEscapedFromDepths)
        {
            return 0;
        }
        
        if (model.ArtefactsScore == 0)
        {
            return 0;
        }

        return model.ArtefactsScore +
            model.TokensScore +
            model.GoldCoinsScore +
            model.DeckValueScore;
    }
}