using System.Collections.Generic;

namespace BGS.ApplicationCore.Games.CalculateScore;

public interface IGameCalculator
{
    IEnumerable<GameCalculationResultModel> Calculate(params PlayerCalculationModel[] models);
}