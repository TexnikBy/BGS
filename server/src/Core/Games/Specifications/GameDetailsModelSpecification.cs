using System;
using Ardalis.Specification;
using BGS.ApplicationCore.Entities;
using BGS.ApplicationCore.Games.Models;

namespace BGS.ApplicationCore.Games.Specifications;

public sealed class GameDetailsModelSpecification : SingleResultSpecification<Game, GameDetailsModel>
{
    public GameDetailsModelSpecification(Guid gameId)
    {
        Query.Where(game => game.Id == gameId);
        Query.Select(game => new GameDetailsModel(game.Name));
    }
}