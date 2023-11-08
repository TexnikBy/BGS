using System;
using BGS.ApplicationCore.Entities;
using MediatR;

namespace BGS.UseCases.Games.GetGameById;

public record GetGameByIdQuery(Guid GameId) : IRequest<Game>;