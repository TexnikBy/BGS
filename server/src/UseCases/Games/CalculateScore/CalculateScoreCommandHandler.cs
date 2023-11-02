using System.Threading;
using System.Threading.Tasks;
using Autofac.Features.Indexed;
using BGS.ApplicationCore.Entities;
using BGS.ApplicationCore.Games.Interfaces;
using BGS.ApplicationCore.Games.Specifications;
using BGS.SharedKernel;
using MediatR;

namespace BGS.UseCases.Games.CalculateScore;

internal class CalculateScoreCommandHandler : IRequestHandler<CalculateScoreCommand, int>
{
    private readonly IIndex<string, IGameScoringStrategy> _gameScoringStrategy;
    private readonly IRepository<Game> _gameRepository;

    public CalculateScoreCommandHandler(
        IIndex<string, IGameScoringStrategy> gameScoringStrategy,
        IRepository<Game> gameRepository)
    {
        _gameScoringStrategy = gameScoringStrategy;
        _gameRepository = gameRepository;
    }

    public async Task<int> Handle(CalculateScoreCommand command, CancellationToken cancellationToken)
    {
        var gameKey = await _gameRepository.SingleOrDefaultAsync(
            new GameKeyByIdSpecification(command.GameId), cancellationToken);

        return _gameScoringStrategy[gameKey].Calculate(command.GameData);
    }
}