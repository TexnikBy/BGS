using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Autofac.Features.Indexed;
using BGS.ApplicationCore.Entities;
using BGS.ApplicationCore.Games.CalculateScore;
using BGS.SharedKernel;
using MediatR;

namespace BGS.UseCases.Games.CalculateScore;

internal class CalculateScoreCommandHandler(
        IIndex<string, IGameCalculator> gameScoringStrategy,
        IRepository<Game> gameRepository)
    : IRequestHandler<CalculateScoreCommand, IEnumerable<GameCalculationResultModel>>
{
    public async Task<IEnumerable<GameCalculationResultModel>> Handle(CalculateScoreCommand command, CancellationToken cancellationToken)
    {
        var gameKey = await gameRepository.SingleOrDefaultAsync(new GameKeyByIdSpecification(command.GameId));
        var scoringStrategy = gameScoringStrategy[gameKey];

        return scoringStrategy.Calculate(command.Models);
    }
}