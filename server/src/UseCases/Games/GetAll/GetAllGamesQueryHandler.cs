using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BGS.ApplicationCore.Entities;
using BGS.SharedKernel;
using MediatR;

namespace BGS.UseCases.Games.GetAll;

public class GetAllGamesQueryHandler : IRequestHandler<GetAllGamesQuery, List<Game>>
{
    private readonly IRepository<Game> _gameRepository;

    public GetAllGamesQueryHandler(IRepository<Game> gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public Task<List<Game>> Handle(GetAllGamesQuery query, CancellationToken cancellationToken)
    {
        return _gameRepository.ListAsync(cancellationToken);
    }
}