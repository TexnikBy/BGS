using BGS.Api.Controllers.Attributes;
using BGS.Api.Controllers.Constants;
using BGS.SharedKernel.Results;
using BGS.UseCases.Games.CalculateScore;
using BGS.UseCases.Games.Create;
using BGS.UseCases.Games.Delete;
using BGS.UseCases.Games.GetAll;
using BGS.UseCases.Games.GetDetails;
using BGS.UseCases.Games.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BGS.Api.Controllers;

[ApiRoute]
[ApiController]
public class GameController(IMediator mediator) : ControllerBase
{
    [HttpPost(Routes.Game.CalculateScore)]
    public Task<int> CalculateScore(CalculateScoreCommand command) => mediator.Send(command);

    [HttpPost]
    public Task<Result> Create(CreateGameCommand command) => mediator.Send(command);

    [HttpGet]
    public Task<List<GameListItem>> GetAll() => mediator.Send(new GetAllGamesQuery());

    [HttpGet(Routes.Game.Details)]
    public Task<GameDetailsModel> GetDetails(Guid gameId) => mediator.Send(new GetDetailsQuery(gameId));

    [HttpPut]
    public Task<Result> UpdateGame(UpdateGameModel model) => mediator.Send(new UpdateGameCommand(model));

    [HttpDelete]
    public Task<Result> DeleteGame(Guid gameId) => mediator.Send(new DeleteGameCommand(gameId));
}