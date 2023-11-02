using System.Threading;
using System.Threading.Tasks;
using Autofac.Features.Indexed;
using BGS.ApplicationCore.Entities;
using BGS.ApplicationCore.Games.Interfaces;
using BGS.ApplicationCore.Games.Specifications;
using BGS.SharedKernel;
using MediatR;

namespace BGS.UseCases.Games.CalculateScore;

internal class CalculateScoreRequestHandler : IRequestHandler<CalculateScoreRequest, int>
{
    private readonly IIndex<string, IGameScoringStrategy> _gameScoringStrategy;
    private readonly IRepository<Game> _gameRepository;

    public CalculateScoreRequestHandler(
        IIndex<string, IGameScoringStrategy> gameScoringStrategy,
        IRepository<Game> gameRepository)
    {
        _gameScoringStrategy = gameScoringStrategy;
        _gameRepository = gameRepository;
    }

    public async Task<int> Handle(CalculateScoreRequest request, CancellationToken cancellationToken)
    {
        var gameKey = await _gameRepository.SingleOrDefaultAsync(
            new GameKeyByIdSpecification(request.GameId), cancellationToken);

        return _gameScoringStrategy[gameKey].Calculate(request.GameData);
    }
}