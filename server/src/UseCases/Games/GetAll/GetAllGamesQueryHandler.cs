using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BGS.ApplicationCore.Entities;
using BGS.ApplicationCore.Games.Models;
using BGS.ApplicationCore.Games.Specifications;
using BGS.SharedKernel;
using MediatR;

namespace BGS.UseCases.Games.GetAll;

public class GetAllGamesQueryHandler : IRequestHandler<GetAllGamesQuery, List<GameListItem>>
{
    private readonly IRepository<Game> _gameRepository;

    public GetAllGamesQueryHandler(IRepository<Game> gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public Task<List<GameListItem>> Handle(GetAllGamesQuery query, CancellationToken cancellationToken)
    {
        return _gameRepository.ListAsync(new GameListItemSpecification(), cancellationToken);
    }
}