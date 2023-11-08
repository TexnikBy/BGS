using BGS.Api.Controllers.Attributes;
using BGS.Api.Controllers.Constants;
using BGS.ApplicationCore.Entities;
using BGS.UseCases.Games.CalculateScore;
using BGS.UseCases.Games.CreateGame;
using BGS.UseCases.Games.GetAllGames;
using BGS.UseCases.Games.GetGameById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BGS.Api.Controllers;

[ApiRoute]
[ApiController]
public class GameController : ControllerBase
{
    private readonly IMediator _mediator;

    public GameController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(Routes.Game.CalculateScore)]
    public Task<int> CalculateScore(CalculateScoreCommand command)
    {
        return _mediator.Send(command);
    }
    
    [HttpPost(Routes.Game.Create)]
    public Task<Game> CreateGame(string gameName)
    {
        return _mediator.Send(new CreateGameCommand(gameName));
    }
    
    [HttpGet(Routes.Game.AllGames)]
    public Task<IEnumerable<Game>> GetAllGames()
    {
        return _mediator.Send(new GetAllGamesQuery());
    }
    
    [HttpGet(Routes.Game.GameById)]
    public Task<Game> GetGameById(Guid gameId)
    {
        return _mediator.Send(new GetGameByIdQuery(gameId));
    }
}