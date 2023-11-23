using System.Threading;
using System.Threading.Tasks;
using BGS.ApplicationCore.Entities;
using BGS.ApplicationCore.Games.Interfaces;
using BGS.SharedKernel;
using BGS.SharedKernel.Results;
using MediatR;

namespace BGS.UseCases.Games.Create;

public class CreateGameCommandHandler(
        IRepository<Game> gameRepository,
        IGameDuplicationChecker gameDuplicationChecker)
    : IRequestHandler<CreateGameCommand, Result>
{
    public async Task<Result> Handle(CreateGameCommand command, CancellationToken cancellationToken)
    {
        if (await gameDuplicationChecker.Check(command.GameName))
        {
            return Result<Result>.Error($"Game with the name {command.GameName} is already exists.");
        }
        
        var newGame = new Game
        {
            Name = command.GameName,
        };
        
        await gameRepository.AddAsync(newGame, cancellationToken);

        return Result.Success();
    }
}