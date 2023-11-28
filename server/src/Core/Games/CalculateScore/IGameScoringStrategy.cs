using System.Text.Json;

namespace BGS.ApplicationCore.Games.CalculateScore;

public interface IGameScoringStrategy
{
    int Calculate(JsonElement scoringData);
}