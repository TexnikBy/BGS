using System.Threading;
using System.Threading.Tasks;
using BGS.ApplicationCore.Entities;
using BGS.SharedKernel;
using BGS.SharedKernel.Results;
using MediatR;

namespace BGS.UseCases.Games.Save;

internal class SaveGameCommandHandler(
        IRepository<Game> gameRepository)
    : IRequestHandler<SaveGameCommand, Result>
{
    public async Task<Result> Handle(SaveGameCommand command, CancellationToken cancellationToken)
    {
        if (await gameRepository.AnyAsync(new GameForSaveSpecification(command.Id, command.Name)))
        {
            return Result.Error($"Game with the name {command.Name} is already exists.");
        }

        if (command.Id.HasValue)
        {
            await Update(command);
        }
        else
        {
            await Create(command);
        }

        return Result.Success();
    }

    private async Task Update(SaveGameCommand command)
    {
        var game = await gameRepository.GetByIdAsync(command.Id);
        game.Name = command.Name;
        game.Key = command.Key;

        await gameRepository.UpdateAsync(game);
    }

    private Task Create(SaveGameCommand command)
    {
        return gameRepository.AddAsync(new Game
        {
            Name = command.Name,
            Key = command.Key,
        });
    }
}