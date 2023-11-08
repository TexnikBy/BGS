using System.Collections.Generic;
using BGS.ApplicationCore.Entities;
using MediatR;

namespace BGS.UseCases.Games.GetAllGames;

public record GetAllGamesQuery : IRequest<IEnumerable<Game>>;