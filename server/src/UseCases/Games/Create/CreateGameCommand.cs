using BGS.SharedKernel.Results;
using MediatR;

namespace BGS.UseCases.Games.Create;

public record CreateGameCommand(string GameName) : IRequest<Result>;