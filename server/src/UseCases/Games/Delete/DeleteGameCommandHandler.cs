using System.Threading;
using System.Threading.Tasks;
using BGS.ApplicationCore.Entities;
using BGS.SharedKernel;
using BGS.SharedKernel.Results;
using MediatR;

namespace BGS.UseCases.Games.Delete;

public class DeleteGameCommandHandler(IRepository<Game> gameRepository) : IRequestHandler<DeleteGameCommand, Result>
{
    public async Task<Result> Handle(DeleteGameCommand command, CancellationToken cancellationToken)
    {
        var game = await gameRepository.GetByIdAsync(command.GameId);
        if (game is null)
        {
            return Result<Result>.Error($"Game with the id {command.GameId} isn't exists.");
        }
        
        await gameRepository.DeleteAsync(game);

        return Result.Success();
    }
}