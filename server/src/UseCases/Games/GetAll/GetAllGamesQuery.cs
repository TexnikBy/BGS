using System.Collections.Generic;
using BGS.ApplicationCore.Entities;
using MediatR;

namespace BGS.UseCases.Games.GetAll;

public record GetAllGamesQuery : IRequest<List<Game>>;