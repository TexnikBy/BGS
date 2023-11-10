using System.Threading;
using System.Threading.Tasks;
using BGS.ApplicationCore.Entities;
using BGS.SharedKernel;
using BGS.SharedKernel.Results;
using MediatR;

namespace BGS.UseCases.Games.Create;

public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, Result>
{
    private readonly IRepository<Game> _gameRepository;

    public CreateGameCommandHandler(IRepository<Game> gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<Result> Handle(CreateGameCommand command, CancellationToken cancellationToken)
    {
        var newGame = new Game
        {
            Name = command.GameName,
        };
        
        await _gameRepository.AddAsync(newGame, cancellationToken);

        return ResultBuilder.BuildSucceed();
    }
}