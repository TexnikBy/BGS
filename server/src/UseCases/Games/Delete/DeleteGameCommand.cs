using System;
using BGS.SharedKernel.Results;
using MediatR;

namespace BGS.UseCases.Games.Delete;

public record DeleteGameCommand(Guid GameId) : IRequest<Result>;