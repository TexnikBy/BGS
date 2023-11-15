using System.Threading;
using System.Threading.Tasks;
using BGS.ApplicationCore.Entities;
using BGS.SharedKernel;
using BGS.SharedKernel.Results;
using MediatR;

namespace BGS.UseCases.Games.Delete;

public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand, Result>
{
    private readonly IRepository<Game> _gameRepository;

    public DeleteGameCommandHandler(IRepository<Game> gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<Result> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.GetByIdAsync(request.GameId, cancellationToken);

        if (game is null)
        {
            return Result.Fail($"Game with the id {request.GameId} isn't exists.");
        }
        
        await _gameRepository.DeleteAsync(game, cancellationToken);

        return Result.Success();
    }
}