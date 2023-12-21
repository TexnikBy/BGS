using BGS.SharedKernel.FileStorages;
using BGS.SharedKernel.Results;
using MediatR;

namespace BGS.UseCases.Games.Create;

public record CreateGameCommand(CreateGameModel Model, FileModel Poster) : IRequest<Result>;