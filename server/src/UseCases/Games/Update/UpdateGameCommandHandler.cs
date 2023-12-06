using System.Threading;
using System.Threading.Tasks;
using BGS.ApplicationCore.Entities;
using BGS.SharedKernel;
using BGS.SharedKernel.FileStorages;
using BGS.SharedKernel.Results;
using MediatR;

namespace BGS.UseCases.Games.Update;

internal class UpdateGameCommandHandler(
        IFileStorage fileStorage,
        IRepository<Game> gameRepository)
    : IRequestHandler<UpdateGameCommand, Result>
{
    public async Task<Result> Handle(UpdateGameCommand command, CancellationToken cancellationToken)
    {
        var (model, poster) = command;
        var game = await gameRepository.GetByIdAsync(model.Id);
        game.Name = model.Name;
        game.Key = model.Key;

        if (poster is not null)
        {
            game.PosterUrl = await fileStorage.Upload(poster);
        }

        await gameRepository.UpdateAsync(game);

        return Result.Success();
    }
}