using BGS.UseCases.Common.Result;
using MediatR;

namespace BGS.UseCases.Games.CreateGame;

public record CreateGameCommand(string GameName) : IRequest<Result>;