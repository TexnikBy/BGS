using System.Threading;
using System.Threading.Tasks;
using BGS.ApplicationCore.Entities;
using BGS.ApplicationCore.Interfaces;
using BGS.SharedKernel;
using BGS.SharedKernel.Results;
using MediatR;

namespace BGS.UseCases.Games.Update;

public class UpdateGameCommandHandler(
        IRepository<Game> gameRepository,
        IGameDuplicationChecker gameDuplicationChecker)
    : IRequestHandler<UpdateGameCommand, Result>
{
    public async Task<Result> Handle(UpdateGameCommand command, CancellationToken cancellationToken)
    {
        if (await gameDuplicationChecker.Check(command.Model.Name))
        {
            return Result<Result>.Error($"Game with the name {command.Model.Name} is already exists.");
        }
        
        var game = await gameRepository.GetByIdAsync(command.Model.Id, cancellationToken);
        game.Name = command.Model.Name;

        await gameRepository.UpdateAsync(game, cancellationToken);

        return Result.Success();
    }
}