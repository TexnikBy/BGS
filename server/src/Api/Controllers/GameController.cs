using BGS.Api.Controllers.Attributes;
using BGS.Api.Controllers.Constants;
using BGS.SharedKernel.Results;
using BGS.UseCases.Games.CalculateScore;
using BGS.UseCases.Games.Create;
using BGS.UseCases.Games.GetAll;
using BGS.UseCases.Games.GetDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
    
    [Authorize]
    [HttpPost]
    public Task<Result> Create(CreateGameCommand command)
    {
        return _mediator.Send(command);
    }
    
    [HttpGet]
    public Task<List<GameListItem>> GetAll()
    {
        return _mediator.Send(new GetAllGamesQuery());
    }
    
    [HttpGet(Routes.Game.Details)]
    public Task<GameDetailsModel> GetDetails(Guid gameId)
    {
        return _mediator.Send(new GetDetailsQuery(gameId));
    }
}