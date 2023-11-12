using System;
using Ardalis.Specification;
using BGS.ApplicationCore.Entities;

namespace BGS.UseCases.Games.GetDetails;

public sealed class GameDetailsModelSpecification : SingleResultSpecification<Game, GameDetailsModel>
{
    public GameDetailsModelSpecification(Guid gameId)
    {
        Query.Where(game => game.Id == gameId);
        Query.Select(game => new GameDetailsModel(game.Name));
    }
}