using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BGS.ApplicationCore.Entities;
using BGS.SharedKernel;
using BGS.SharedKernel.Results;
using MediatR;

namespace BGS.UseCases.Games.Update;

public class UpdateGameCommandHandler(IRepository<Game> gameRepository) : IRequestHandler<UpdateGameCommand, Result>
{
    public async Task<Result> Handle(UpdateGameCommand command, CancellationToken cancellationToken)
    {
        var existingGames = await gameRepository.ListAsync(cancellationToken);
        var hasDuplication = existingGames.Any(item =>
            string.Equals(item.Name, command.Model.Name, StringComparison.InvariantCultureIgnoreCase));

        if (hasDuplication)
        {
            return Result.Fail($"Game with the name {command.Model.Name} is already exists.");
        }
        
        var game = await gameRepository.GetByIdAsync(command.Model.Id, cancellationToken);
        game.Name = command.Model.Name;

        await gameRepository.UpdateAsync(game, cancellationToken);

        return Result.Success();
    }
}