using System.Text.Json;

namespace BGS.ApplicationCore.Games.Interfaces;

public interface IGameScoringStrategy
{
    int Calculate(JsonElement scoringData);
}