using System;
using BGS.SharedKernel.Results;
using MediatR;

namespace BGS.UseCases.Games.Update;

public record UpdateGameCommand(Guid GameId, UpdateGameModel Model) : IRequest<Result>;