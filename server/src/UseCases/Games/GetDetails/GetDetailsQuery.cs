using System;
using BGS.ApplicationCore.Entities;
using MediatR;

namespace BGS.UseCases.Games.GetDetails;

public record GetDetailsQuery(Guid GameId) : IRequest<Game>;