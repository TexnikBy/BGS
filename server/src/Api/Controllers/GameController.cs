using BGS.Api.Controllers.Attributes;
using BGS.Api.Controllers.Constants;
using BGS.ApplicationCore.Entities;
using BGS.UseCases.Games.CalculateScore;
using BGS.UseCases.Games.CreateGame;
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
}