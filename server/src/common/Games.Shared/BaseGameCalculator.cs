using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using BGS.ApplicationCore.Games.CalculateScore;
using BGS.Games.Shared.Interfaces;
using BGS.Games.Shared.Models;

namespace BGS.Games.Shared;

public abstract class BaseGameCalculator<T> : IGameCalculator where T : IGameScoringModel<T>
{
    private readonly JsonSerializerOptions _serializerOptions = new ()
    {
        PropertyNameCaseInsensitive = true,
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
    };

    public IEnumerable<GameCalculationResultModel> Calculate(params PlayerCalculationModel[] models)
    {
        return SetPlacesAndMapToGameCalculationResultModel(models
            .Select(
                model => new GameCalculationModel<T>
                {
                    PlayerNumber = model.PlayerNumber,
                    PlayerName = model.PlayerName,
                    ScoringModel = model.GameData.Deserialize<T>(_serializerOptions),
                })
            .OrderByDescending(x => x.ScoringModel));
    }

    private static List<GameCalculationResultModel> SetPlacesAndMapToGameCalculationResultModel(
        IEnumerable<GameCalculationModel<T>> models)
    {
        var source = new List<GameCalculationModel<T>>(models);
        var result = new List<GameCalculationResultModel>();
        for (var i = 0; i < source.Count; i++)
        {
            if (i == 0)
            {
                result.Add(MapToGameCalculationResultModel(source[i], 1));
                continue;
            }

            result.Add(
                source[i - 1].ScoringModel.CompareTo(source[i].ScoringModel) == 0
                    ? MapToGameCalculationResultModel(source[i], result[i - 1].Place)
                    : MapToGameCalculationResultModel(source[i], result[i - 1].Place + 1));
        }

        return result;
    }

    private static GameCalculationResultModel MapToGameCalculationResultModel(
        GameCalculationModel<T> source, int place)
    {
        return new GameCalculationResultModel
        {
            Place = place,
            PlayerNumber = source.PlayerNumber,
            PlayerName = source.PlayerName,
            TotalScore = source.ScoringModel.TotalScore,
        };
    }
}