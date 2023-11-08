using BGS.ApplicationCore.Entities;
using MediatR;

namespace BGS.UseCases.Games.CreateGame;

public record CreateGameCommand(string GameName) : IRequest<Game>;