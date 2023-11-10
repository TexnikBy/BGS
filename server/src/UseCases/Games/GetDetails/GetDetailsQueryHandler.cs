using System.Threading;
using System.Threading.Tasks;
using BGS.ApplicationCore.Entities;
using BGS.ApplicationCore.Games.Specifications;
using BGS.ApplicationCore.Models;
using BGS.SharedKernel;
using MediatR;

namespace BGS.UseCases.Games.GetDetails;

public class GetDetailsQueryHandler : IRequestHandler<GetDetailsQuery, GameDetailsResponse>
{
    private readonly IRepository<Game> _gameRepository;

    public GetDetailsQueryHandler(IRepository<Game> gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public Task<GameDetailsResponse> Handle(GetDetailsQuery query, CancellationToken cancellationToken)
    {
        return _gameRepository.SingleOrDefaultAsync(new GameDetailsSpecification(query.GameId), cancellationToken);
    }
}