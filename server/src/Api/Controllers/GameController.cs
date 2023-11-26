using BGS.Api.Controllers.Attributes;
using BGS.Api.Controllers.Constants;
using BGS.SharedKernel.Results;
using BGS.UseCases.Games.CalculateScore;
using BGS.UseCases.Games.Delete;
using BGS.UseCases.Games.GetAll;
using BGS.UseCases.Games.Save;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BGS.Api.Controllers;

[ApiRoute]
[ApiController]
public class GameController(IMediator mediator) : ControllerBase
{
    [HttpPost(Routes.Game.CalculateScore)]
    public Task<int> CalculateScore(CalculateScoreCommand command) => mediator.Send(command);

    [HttpGet]
    public Task<List<GameListItem>> GetAll() => mediator.Send(new GetAllGamesQuery());

    [Authorize]
    [HttpPost]
    public Task<Result> Save(SaveGameCommand command) => mediator.Send(command);

    [Authorize]
    [HttpDelete]
    public Task<Result> DeleteGame(Guid gameId) => mediator.Send(new DeleteGameCommand(gameId));
}