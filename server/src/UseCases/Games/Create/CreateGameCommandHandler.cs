using System.Threading;
using System.Threading.Tasks;
using BGS.ApplicationCore.Entities;
using BGS.SharedKernel;
using BGS.SharedKernel.FileStorages;
using BGS.SharedKernel.Results;
using MediatR;

namespace BGS.UseCases.Games.Create;

internal class CreateGameCommandHandler(
        IRepository<Game> gameRepository,
        IFileStorage fileStorage)
    : IRequestHandler<CreateGameCommand, Result>
{
    public async Task<Result> Handle(CreateGameCommand command, CancellationToken cancellationToken)
    {
        var (model, poster) = command;
        await gameRepository.AddAsync(new Game
        {
            Name = model.Name,
            Key = model.Key,
            PosterUrl = await fileStorage.Upload(poster),
        });

        return Result.Success();
    }
}