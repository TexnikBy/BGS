using BGS.Api.Controllers.Attributes;
using BGS.Api.Controllers.Constants;
using BGS.UseCases.Games.CalculateScore;
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

    [HttpGet(Routes.Game.CalculateScore)]
    public Task<int> CalculateScore(CalculateScoreRequest request)
    {
        return _mediator.Send(request);
    }
}