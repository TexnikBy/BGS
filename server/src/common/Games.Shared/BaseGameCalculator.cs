using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using BGS.ApplicationCore.Games.CalculateScore;

namespace BGS.Games.Shared;

public abstract class BaseGameCalculator<T> : IGameCalculator
{
    private readonly JsonSerializerOptions _jsonSerializerOptions = new ()
    {
        PropertyNameCaseInsensitive = true,
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
    };

    protected abstract int CalculateTotalScore(T gameData);

    public IEnumerable<GameCalculationResultModel> Calculate(params PlayerCalculationModel[] models)
    {
        var result = new List<GameCalculationResultModel>();
        foreach (var model in models)
        {
            result.Add(new GameCalculationResultModel
            {
                PlayerNumber = model.PlayerNumber,
                PlayerName = model.PlayerName,
                TotalScore = CalculateTotalScore(Deserialize(model.GameData)),
            });
        }

        return result.OrderByDescending(model => model.TotalScore);
    }

    private T Deserialize(JsonElement scoringData)
    {
        return scoringData.Deserialize<T>(_jsonSerializerOptions);
    }
}