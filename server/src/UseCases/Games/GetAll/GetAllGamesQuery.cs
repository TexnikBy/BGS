using System.Collections.Generic;
using MediatR;

namespace BGS.UseCases.Games.GetAll;

public record GetAllGamesQuery : IRequest<List<GameListItem>>;