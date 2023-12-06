using BGS.Api.Controllers.Attributes;
using BGS.Api.Controllers.Constants;
using BGS.Api.Extensions;
using BGS.SharedKernel.Results;
using BGS.UseCases.Games.CalculateScore;
using BGS.UseCases.Games.Create;
using BGS.UseCases.Games.Delete;
using BGS.UseCases.Games.GetAll;
using BGS.UseCases.Games.Update;
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

    [HttpPost]
    public Task<Result> Create([FromForm] CreateGameModel model, IFormFile poster) =>
        mediator.Send(new CreateGameCommand(model, poster.ToFileModel()));

    [HttpPut]
    public Task<Result> Update([FromForm] UpdateGameModel model, IFormFile poster) =>
        mediator.Send(new UpdateGameCommand(model, poster.ToFileModel()));

    [Authorize]
    [HttpDelete]
    public Task<Result> DeleteGame(Guid gameId) => mediator.Send(new DeleteGameCommand(gameId));
}