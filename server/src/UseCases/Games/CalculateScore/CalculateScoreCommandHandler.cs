using System.Threading;
using System.Threading.Tasks;
using Autofac.Features.Indexed;
using BGS.ApplicationCore.Entities;
using BGS.ApplicationCore.Games.CalculateScore;
using BGS.SharedKernel;
using MediatR;

namespace BGS.UseCases.Games.CalculateScore;

internal class CalculateScoreCommandHandler(
        IIndex<string, IGameScoringStrategy> gameScoringStrategy,
        IRepository<Game> gameRepository)
    : IRequestHandler<CalculateScoreCommand, int>
{
    public async Task<int> Handle(CalculateScoreCommand command, CancellationToken cancellationToken)
    {
        var gameKey = await gameRepository.SingleOrDefaultAsync(new GameKeyByIdSpecification(command.GameId));

        return gameScoringStrategy[gameKey].Calculate(command.GameData);
    }
}