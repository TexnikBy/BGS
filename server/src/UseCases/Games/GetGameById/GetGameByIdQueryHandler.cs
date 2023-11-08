using System.Threading;
using System.Threading.Tasks;
using BGS.ApplicationCore.Entities;
using BGS.SharedKernel;
using MediatR;

namespace BGS.UseCases.Games.GetGameById;

public class GetGameByIdQueryHandler : IRequestHandler<GetGameByIdQuery, Game>
{
    private readonly IRepository<Game> _gameRepository;

    public GetGameByIdQueryHandler(IRepository<Game> gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<Game> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
    {
        return await _gameRepository.GetByIdAsync(request.GameId, cancellationToken);
    }
}