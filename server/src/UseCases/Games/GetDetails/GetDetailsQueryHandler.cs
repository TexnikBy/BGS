using System.Threading;
using System.Threading.Tasks;
using BGS.ApplicationCore.Entities;
using BGS.SharedKernel;
using MediatR;

namespace BGS.UseCases.Games.GetDetails;

public class GetDetailsQueryHandler : IRequestHandler<GetDetailsQuery, Game>
{
    private readonly IRepository<Game> _gameRepository;

    public GetDetailsQueryHandler(IRepository<Game> gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<Game> Handle(GetDetailsQuery query, CancellationToken cancellationToken)
    {
        return await _gameRepository.GetByIdAsync(query.GameId, cancellationToken);
    }
}