using System.Threading;
using System.Threading.Tasks;
using BGS.ApplicationCore.Entities;
using BGS.SharedKernel;
using BGS.UseCases.Common.Result;
using MediatR;

namespace BGS.UseCases.Games.CreateGame;

public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, Result>
{
    private readonly IRepository<Game> _gameRepository;

    public CreateGameCommandHandler(IRepository<Game> gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<Result> Handle(CreateGameCommand request, CancellationToken cancellationToken)
    {
        var newGame = new Game
        {
            Name = request.GameName,
            Key = request.GameName.Replace(" ", ""),
        };
        
        await _gameRepository.AddAsync(newGame, cancellationToken);

        return await ResultBuilder.BuildSucceed();
    }
}