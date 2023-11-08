using System.Threading;
using System.Threading.Tasks;
using BGS.ApplicationCore.Entities;
using BGS.SharedKernel;
using MediatR;

namespace BGS.UseCases.Games.CreateGame;

public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, Game>
{
    private readonly IRepository<Game> _gameRepository;

    public CreateGameCommandHandler(IRepository<Game> gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<Game> Handle(CreateGameCommand request, CancellationToken cancellationToken)
    {
        var newGame = new Game
        {
            Name = request.GameName,
            Key = request.GameName.Replace(" ", ""),
        };
        
        return await _gameRepository.AddAsync(newGame, cancellationToken);
    }
}