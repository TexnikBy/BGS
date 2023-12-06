using BGS.SharedKernel.FileStorages;
using BGS.SharedKernel.Results;
using MediatR;

namespace BGS.UseCases.Games.Update;

public record UpdateGameCommand(UpdateGameModel Model, FileModel Poster) : IRequest<Result>;