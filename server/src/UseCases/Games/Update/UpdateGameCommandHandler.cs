using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BGS.ApplicationCore.Entities;
using BGS.SharedKernel;
using BGS.SharedKernel.Results;
using MediatR;

namespace BGS.UseCases.Games.Update;

public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, Result>
{
    private readonly IRepository<Game> _gameRepository;

    public UpdateGameCommandHandler(IRepository<Game> gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<Result> Handle(UpdateGameCommand command, CancellationToken cancellationToken)
    {
        var existingGames = await _gameRepository.ListAsync(cancellationToken);
        var hasDuplication = existingGames.Any(item =>
            string.Equals(item.Name, command.Model.Name, StringComparison.InvariantCultureIgnoreCase));

        if (hasDuplication)
        {
            return Result.Fail($"Game with the name {command.Model.Name} is already exists.");
        }
        
        var game = await _gameRepository.GetByIdAsync(command.GameId, cancellationToken);
        game.Name = command.Model.Name;

        await _gameRepository.UpdateAsync(game, cancellationToken);

        return Result.Success();
    }
}