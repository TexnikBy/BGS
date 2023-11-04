using System.Text.Json;
using BGS.ApplicationCore.Games.Interfaces;

namespace BGS.Games.BattleForRokugan;

internal class BattleForRokuganScoringStrategy : IGameScoringStrategy
{
    public int Calculate(JsonElement scoringData)
    {
        var model = scoringData.Deserialize<BattleForRokuganScoringModel>();

        return model.CountOfProvincialFlowers +
               model.CountOfFaceUpControlTokens +
               model.SecretObjectivePoints +
               model.CountOfControlledTerritories * 5;
    }
}