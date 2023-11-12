using System;
using BGS.ApplicationCore.Games.Models;
using MediatR;

namespace BGS.UseCases.Games.GetDetails;

public record GetDetailsQuery(Guid GameId) : IRequest<GameDetailsModel>;