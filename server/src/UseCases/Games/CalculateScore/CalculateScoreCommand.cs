using System.Collections.Generic;
using BGS.ApplicationCore.Games.CalculateScore;
using MediatR;

namespace BGS.UseCases.Games.CalculateScore;

public record CalculateScoreCommand(int GameId, PlayerCalculationModel[] Models)
    : IRequest<IEnumerable<GameCalculationResultModel>>;