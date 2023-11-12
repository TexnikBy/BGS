using System;
using MediatR;

namespace BGS.UseCases.Games.GetDetails;

public record GetDetailsQuery(Guid GameId) : IRequest<GameDetailsModel>;