using BGS.Api.Controllers.Attributes;
using BGS.Api.Controllers.Constants;
using BGS.ApplicationCore.Entities;
using BGS.SharedKernel.Results;
using BGS.UseCases.Games.CalculateScore;
using BGS.UseCases.Games.Create;
using BGS.UseCases.Games.GetAll;
using BGS.UseCases.Games.GetDetails;
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
    public Task<Result> Create(string gameName)
    {
        return _mediator.Send(new CreateGameCommand(gameName));
    }
    
    [HttpGet(Routes.Game.AllGames)]
    public Task<IEnumerable<Game>> GetAll()
    {
        return _mediator.Send(new GetAllGamesQuery());
    }
    
    [HttpGet(Routes.Game.Details)]
    public Task<Game> GetDetails(Guid gameId)
    {
        return _mediator.Send(new GetDetailsQuery(gameId));
    }
}